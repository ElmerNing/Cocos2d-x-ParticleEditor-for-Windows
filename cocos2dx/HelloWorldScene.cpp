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

	return true;
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

		CCLabelTTFEx* ex = CCLabelTTFEx::labelWithString("123", "", 100);
		//ex->setColor(ccBLACK);
		//ex->setStroke(2,ccWHITE);
		ex->setPosition(ccp(400,400));
		mUiNode->addChild(ex);
	}
}

bool HelloWorld::mIsBackgroundMove;

CCSprite* HelloWorld::mBackground;

CCParticleSystem* HelloWorld::mEmiiter;

CCNode* HelloWorld::mUiNode;
