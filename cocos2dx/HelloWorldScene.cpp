#include "HelloWorldScene.h"
#include "AppMacros.h"
#include "support/zip_support/ZipUtils.h"
#include "support/base64.h"

USING_NS_CC;

CCScene* HelloWorld::scene()
{
	// 'scene' is an autorelease object
	CCScene *scene = CCScene::create();

	// 'layer' is an autorelease object
	HelloWorld *layer = HelloWorld::create();

	// add layer as a child to scene
	scene->addChild(layer);

	// return the scene
	return scene;
}

// on "init" you need to initialize your instance
bool HelloWorld::init()
{
	//////////////////////////////
	// 1. super init first
	if ( !CCLayer::init() )
	{
		return false;
	}

	CCSize size= CCDirector::sharedDirector()->getWinSize();

	mBackground=CCSprite::create("background.png");
	mBackground->setAnchorPoint(ccp(0.5f,0.5f));
	mBackground->setPosition(ccp(size.width/2,size.height/2));

	this->addChild(mBackground,1,1);

	mUiNode = CCNode::create();
	mUiNode->setContentSize(size);
	mUiNode->setAnchorPoint(ccp(0.5f,0.5f));
	mUiNode->setPosition(ccp(size.width/2,size.height/2));
	this->addChild(mUiNode,2,2);

// 	CCActionInterval* move1 = CCMoveBy::create(4, CCPointMake(100,0) );
// 	CCActionInterval* move2 = CCMoveBy::create(4, CCPointMake(0,100) );
// 	CCActionInterval* move3 = CCMoveBy::create(4, CCPointMake(-100,0) );
// 	CCActionInterval* move4 = CCMoveBy::create(4, CCPointMake(0,-100) );
// 
// 	CCFiniteTimeAction* seq = CCSequence::create(move1, move2, move3,move4,NULL);
// 	mBackground->runAction( CCRepeatForever::create((CCActionInterval*)seq) );
// 
// 	mEmiiter=new CCParticleSun();
// 
// 	mEmiiter->initWithTotalParticles(350);
// 	mEmiiter->setTexture(CCTextureCache::sharedTextureCache()->addImage("fire.png"));
// 	
// 	CCSize s = CCDirector::sharedDirector()->getWinSize();
// 	
// 	mBackground->addChild(mEmiiter,1);
// 	mEmiiter->setPosition(ccp(size.width/2,size.height/2));
// 	mIsBackgroundMove=true;
	return true;
}

void HelloWorld::ChangeParticle(float scale,bool isBackgroundMove,float angle,float angleVar,int destBlendFunc,int srcBlendFunc,float duration,float emissionRate,int emiiterMode,
	GLbyte endColorR,GLbyte endColorG,GLbyte endColorB,GLbyte endColorA,
	GLbyte endColorVarR,GLbyte endColorVarG,GLbyte endColorVarB,GLbyte endColorVarA,
	float endRadius,float endRadiusVar,
	float endSize,float endSizeVar,
	float endSpin,float endSpinVar,
	float gravityX,float gravityY,
	bool isAutoRemoveOnFinish,
	float life,float lifeVar,
	int positionType,
	float positionVarX,float positionVarY,
	float radialAccel,float radialAccelVar,
	float rotatePerSecond,float rotatePerSecondVar,
	float sourcePositionX,float sourcePositionY,
	float speed,float speedVar,
	GLbyte startColorR,GLbyte startColorG,GLbyte startColorB,GLbyte startColorA,
	GLbyte startColorVarR,GLbyte startColorVarG,GLbyte startColorVarB,GLbyte startColorVarA,
	float startRadius,float startRadiusVar,
	float startSize,float startSizeVar,
	float startSpin,float startSpinVar,
	float tangentialAccel,float tangentialAccelVar,
	char* plistPath,char* texturePath,char* textureImageData,
	unsigned int totalParticles
	)
{

	if (texturePath==NULL||strlen(texturePath)==0)
	{
		return;
	}

	mBackground->setScale(scale);

	CCSize size= CCDirector::sharedDirector()->getWinSize();

	if (totalParticles!=mEmiiter->getTotalParticles())
	{
		mEmiiter->removeFromParentAndCleanup(true);

		mEmiiter=new CCParticleSystemQuad();

		mEmiiter->initWithTotalParticles(totalParticles);
		mEmiiter->setPosition(ccp(size.width/2,size.height/2));

		mEmiiter->setTexture(CCTextureCache::sharedTextureCache()->addImage("fire.png"));

		mBackground->addChild(mEmiiter,1);
	}

	if (isBackgroundMove!=mIsBackgroundMove)
	{
		mIsBackgroundMove=isBackgroundMove;


		mBackground->stopAllActions();
		mBackground->setPosition(ccp(size.width/2,size.height/2));

		if (mIsBackgroundMove)
		{
			CCActionInterval* move1 = CCMoveBy::create(4, CCPointMake(100,0) );
			CCActionInterval* move2 = CCMoveBy::create(4, CCPointMake(0,100) );
			CCActionInterval* move3 = CCMoveBy::create(4, CCPointMake(-100,0) );
			CCActionInterval* move4 = CCMoveBy::create(4, CCPointMake(0,-100) );

			CCFiniteTimeAction* seq = CCSequence::create(move1, move2, move3,move4,NULL);
			mBackground->runAction( CCRepeatForever::create((CCActionInterval*)seq) );
		}
	}

	CCTexture2D *tex = NULL;

	if (texturePath!=NULL)
	{
		// set not pop-up message box when load image failed
		bool bNotify = CCFileUtils::sharedFileUtils()->isPopupNotify();
		CCFileUtils::sharedFileUtils()->setPopupNotify(false);


		//tex = CCTextureCache::sharedTextureCache()->addImage(texturePath);
		if (tex==NULL)
		{
			std::string secondPath=plistPath;
			secondPath+="/";
			secondPath+=texturePath;
			tex = CCTextureCache::sharedTextureCache()->addImage(secondPath.c_str());
		}
		
		// reset the value of UIImage notify
		CCFileUtils::sharedFileUtils()->setPopupNotify(bNotify);
	}

	if (tex)
	{
		mEmiiter->setTexture(tex);
	}
	else
	{                        
		
		unsigned char *buffer = NULL;
		unsigned char *deflated = NULL;
		CCImage *image = NULL;

		CCAssert(textureImageData, "");

		int dataLen = strlen(textureImageData);
		if(dataLen != 0)
		{
			// if it fails, try to get it from the base64-gzipped data    
			int decodeLen = base64Decode((unsigned char*)textureImageData, (unsigned int)dataLen, &buffer);
			CCAssert( buffer != NULL, "CCParticleSystem: error decoding textureImageData");


			int deflatedLen = ZipUtils::ccInflateMemory(buffer, decodeLen, &deflated);
			CCAssert( deflated != NULL, "CCParticleSystem: error ungzipping textureImageData");

			// For android, we should retain it in VolatileTexture::addCCImage which invoked in CCTextureCache::sharedTextureCache()->addUIImage()
			image = new CCImage();
			bool isOK = image->initWithImageData(deflated, deflatedLen);
			CCAssert(isOK, "CCParticleSystem: error init image with Data");

			mEmiiter->setTexture(CCTextureCache::sharedTextureCache()->addUIImage(image, texturePath));

			image->release();
		}

		CC_SAFE_DELETE_ARRAY(buffer);
		CC_SAFE_DELETE_ARRAY(deflated);
	}

	mEmiiter->setAngle(angle);
	mEmiiter->setAngleVar(angleVar);


	ccBlendFunc func;
	func.dst=destBlendFunc;
	func.src=srcBlendFunc;
	mEmiiter->setBlendFunc(func);

	mEmiiter->setDuration(duration);
	mEmiiter->setEmissionRate(emissionRate);
	mEmiiter->setEmitterMode(emiiterMode);

	ccColor4F endColor=ccc4FFromccc4B(ccc4(endColorR,endColorG,endColorB,endColorA));
	mEmiiter->setEndColor(endColor);

	ccColor4F endColorVar=ccc4FFromccc4B(ccc4(endColorVarR,endColorVarG,endColorVarB,endColorVarA));
	mEmiiter->setEndColorVar(endColorVar);

	if (emiiterMode==kCCParticleModeGravity )
	{
		mEmiiter->setGravity(ccp(gravityX,gravityY));
		mEmiiter->setSpeed(speed);
		mEmiiter->setSpeedVar(speedVar);

		mEmiiter->setTangentialAccel(tangentialAccel);
		mEmiiter->setTangentialAccelVar(tangentialAccelVar);

		mEmiiter->setRadialAccel(radialAccel);
		mEmiiter->setRadialAccelVar(radialAccelVar);

	}
	else if (emiiterMode==kCCParticleModeRadius)
	{
		mEmiiter->setStartRadius(startRadius);
		mEmiiter->setStartRadiusVar(startRadiusVar);

		mEmiiter->setEndRadius(endRadius);
		mEmiiter->setEndRadiusVar(endRadiusVar);

		mEmiiter->setRotatePerSecond(rotatePerSecond);
		mEmiiter->setRotatePerSecondVar(rotatePerSecondVar);
	}



	mEmiiter->setEndSize(endSize);
	mEmiiter->setEndSizeVar(endSizeVar);

	mEmiiter->setEndSpin(endSpin);
	mEmiiter->setEndSpinVar(endSpinVar);

	mEmiiter->setAutoRemoveOnFinish(isAutoRemoveOnFinish);

	mEmiiter->setLife(life);
	mEmiiter->setLifeVar(lifeVar);
	mEmiiter->setPositionType((tCCPositionType)positionType);
	mEmiiter->setPosVar(ccp(positionVarX,positionVarY));

	mEmiiter->setSourcePosition(ccp(sourcePositionX,sourcePositionY));

	ccColor4F startColor=ccc4FFromccc4B(ccc4(startColorR,startColorG,startColorB,startColorA));
	mEmiiter->setStartColor(startColor);

	ccColor4F startColorVar=ccc4FFromccc4B(ccc4(startColorVarR,startColorVarG,startColorVarB,startColorVarA));
	mEmiiter->setStartColorVar(startColorVar);

	mEmiiter->setStartSize(startSize);
	mEmiiter->setStartSizeVar(startSizeVar);

	
	mEmiiter->setTotalParticles(totalParticles);

	mEmiiter->resetSystem();
}

void HelloWorld::ChangeUi( CCNode* node )
{
	mUiNode->removeAllChildren();

	if (node)
	{
		mUiNode->addChild(node,2,1);
	}else
	{/*
		//CCSprite* sprite = CCSprite::createWithSpriteFrameName("s_crusade_update_tile.png");
		CCSprite* sprite = CCSprite::create("123.jpg");
		sprite->setPosition(ccp(mUiNode->getContentSize().width*0.5f, mUiNode->getContentSize().height*0.5));
		sprite->setAnchorPoint(ccp(0.5,0.5));
		sprite->setRotation(100);
		CCNode* node = CCNode::create();
		//node->addChild(sprite);
		mUiNode->addChild(sprite);*/
		CCMenu* menu = CCMenu::create();
		menu->setPosition(CCPointZero);

		char norm[32];
		char sel[32];
		sprintf(norm, "uc_btn_%d_n.png", 4);
		sprintf(sel, "uc_btn_%d_t.png", 4);
		CCMenuItemSprite* item = CCMenuItemSprite::create(
			CCSprite::createWithSpriteFrameName(norm),
			CCSprite::createWithSpriteFrameName(sel),
			CCSprite::createWithSpriteFrameName("uc_btn_1_disable.png")
			);
		item->setPosition(ccp(500,500));
		menu->addChild(item);

		CCLabelTTF* label = CCLabelTTF::create("abcc","", 30);
		item->addChild(label);
		mUiNode->addChild(menu);

	}
}

bool HelloWorld::mIsBackgroundMove;

CCSprite* HelloWorld::mBackground;

CCParticleSystem* HelloWorld::mEmiiter;

CCNode* HelloWorld::mUiNode;
