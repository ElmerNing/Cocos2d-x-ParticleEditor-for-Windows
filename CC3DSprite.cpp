#include "CC3DSprite.h"

CC3DSprite::CC3DSprite()
	:m_pobTexture(NULL)
{

}

CC3DSprite::~CC3DSprite()
{
	CC_SAFE_RELEASE(m_pobTexture);
}

CC3DSprite* CC3DSprite::createWithTexture(CCTexture2D *pTexture)
{
	CC3DSprite *pobSprite = new CC3DSprite();
	if (pobSprite && pobSprite->initWithTexture(pTexture))
	{
		pobSprite->autorelease();
		return pobSprite;
	}
	CC_SAFE_DELETE(pobSprite);
	return NULL;
}

CC3DSprite* CC3DSprite::createWithTexture(CCTexture2D *pTexture, const CCRect& rect)
{
	CC3DSprite *pobSprite = new CC3DSprite();
	if (pobSprite && pobSprite->initWithTexture(pTexture, rect))
	{
		pobSprite->autorelease();
		return pobSprite;
	}
	CC_SAFE_DELETE(pobSprite);
	return NULL;
}

CC3DSprite* CC3DSprite::create(const char *pszFileName)
{
	CC3DSprite *pobSprite = new CC3DSprite();
	if (pobSprite && pobSprite->initWithFile(pszFileName))
	{
		pobSprite->autorelease();
		return pobSprite;
	}
	CC_SAFE_DELETE(pobSprite);
	return NULL;
}

CC3DSprite* CC3DSprite::create(const char *pszFileName, const CCRect& rect)
{
	CC3DSprite *pobSprite = new CC3DSprite();
	if (pobSprite && pobSprite->initWithFile(pszFileName, rect))
	{
		pobSprite->autorelease();
		return pobSprite;
	}
	CC_SAFE_DELETE(pobSprite);
	return NULL;
}

CC3DSprite* CC3DSprite::createWithSpriteFrame(CCSpriteFrame *pSpriteFrame)
{
	CC3DSprite *pobSprite = new CC3DSprite();
	if (pSpriteFrame && pobSprite && pobSprite->initWithSpriteFrame(pSpriteFrame))
	{
		pobSprite->autorelease();
		return pobSprite;
	}
	CC_SAFE_DELETE(pobSprite);
	return NULL;
}

CC3DSprite* CC3DSprite::createWithSpriteFrameName(const char *pszSpriteFrameName)
{
	CCSpriteFrame *pFrame = CCSpriteFrameCache::sharedSpriteFrameCache()->spriteFrameByName(pszSpriteFrameName);

#if COCOS2D_DEBUG > 0
	char msg[256] = {0};
	sprintf(msg, "Invalid spriteFrameName: %s", pszSpriteFrameName);
	CCAssert(pFrame != NULL, msg);
#endif

	return createWithSpriteFrame(pFrame);
}

CC3DSprite* CC3DSprite::create()
{
	CC3DSprite *pSprite = new CC3DSprite();
	if (pSprite && pSprite->init())
	{
		pSprite->autorelease();
		return pSprite;
	}
	CC_SAFE_DELETE(pSprite);
	return NULL;
}

bool CC3DSprite::init(void)
{
	return initWithTexture(NULL, CCRectZero);
}

// designated initializer
bool CC3DSprite::initWithTexture(CCTexture2D *pTexture, const CCRect& rect, bool rotated)
{
	if (CCNode::init())
	{
		// clean the Quad
		memset(&m_sQuad, 0, sizeof(m_sQuad));

		// Atlas: Color
		ccColor4B tmpColor = { 255, 255, 255, 255 };
		m_sQuad.bl.colors = tmpColor;
		m_sQuad.br.colors = tmpColor;
		m_sQuad.tl.colors = tmpColor;
		m_sQuad.tr.colors = tmpColor;

		// shader program
		setShaderProgram(CCShaderCache::sharedShaderCache()->programForKey(kCCShader_PositionTextureColor));

		//set texture
		setTexture(pTexture);

		//set textureRect 
		setTextureRect(rect, rotated);

		return true;
	}
	else
	{
		return false;
	}
}

bool CC3DSprite::initWithTexture(CCTexture2D *pTexture, const CCRect& rect)
{
	return initWithTexture(pTexture, rect, false);
}

bool CC3DSprite::initWithTexture(CCTexture2D *pTexture)
{
	CCAssert(pTexture != NULL, "Invalid texture for sprite");

	CCRect rect = CCRectZero;
	rect.size = pTexture->getContentSize();

	return initWithTexture(pTexture, rect);
}

bool CC3DSprite::initWithFile(const char *pszFilename)
{
	CCAssert(pszFilename != NULL, "Invalid filename for sprite");

	CCTexture2D *pTexture = CCTextureCache::sharedTextureCache()->addImage(pszFilename);
	if (pTexture)
	{
		CCRect rect = CCRectZero;
		rect.size = pTexture->getContentSize();
		return initWithTexture(pTexture, rect);
	}

	// don't release here.
	// when load texture failed, it's better to get a "transparent" sprite then a crashed program
	// this->release(); 
	return false;
}

bool CC3DSprite::initWithFile(const char *pszFilename, const CCRect& rect)
{
	CCAssert(pszFilename != NULL, "");

	CCTexture2D *pTexture = CCTextureCache::sharedTextureCache()->addImage(pszFilename);
	if (pTexture)
	{
		return initWithTexture(pTexture, rect);
	}

	// don't release here.
	// when load texture failed, it's better to get a "transparent" sprite then a crashed program
	// this->release(); 
	return false;
}

bool CC3DSprite::initWithSpriteFrame(CCSpriteFrame *pSpriteFrame)
{
	CCAssert(pSpriteFrame != NULL, "");
	
	bool bRet = initWithTexture(pSpriteFrame->getTexture(), pSpriteFrame->getRect());
	//setDisplayFrame(pSpriteFrame);

	return bRet;
}

bool CC3DSprite::initWithSpriteFrameName(const char *pszSpriteFrameName)
{
	CCAssert(pszSpriteFrameName != NULL, "");

	CCSpriteFrame *pFrame = CCSpriteFrameCache::sharedSpriteFrameCache()->spriteFrameByName(pszSpriteFrameName);
	return initWithSpriteFrame(pFrame);
}

void CC3DSprite::setDisplayFrame(CCSpriteFrame *pNewFrame)
{
	CCAssert(pNewFrame != NULL, "CCSprite::setDisplayFrame() - Invalid frame");

	CCTexture2D *pNewTexture = pNewFrame->getTexture();

	if (pNewTexture != m_pobTexture)
	{
		setTexture(pNewTexture);
	}

	setTextureRect(pNewFrame->getRect(), pNewFrame->isRotated());
}

void CC3DSprite::setTextureRect(const CCRect& rect, bool rotated)
{
	this->setContentSize(rect.size);

	//TextureCoords
	updateTextureCoords(rect, rotated);
	
	 m_bTransformDirty = m_bInverseDirty = true;
}

void CC3DSprite::setTexture(CCTexture2D *texture)
{
	if (m_pobTexture != texture)
	{
		CC_SAFE_RETAIN(texture);
		CC_SAFE_RELEASE(m_pobTexture);
		m_pobTexture = texture;
	}
}

CCTexture2D* CC3DSprite::getTexture(void)
{
	return m_pobTexture;
}

void CC3DSprite::updateVertexRect()
{
	float x1 = -m_obContentSize.width * this->m_obAnchorPoint.x;
	float y1 = -m_obContentSize.height * this->m_obAnchorPoint.y;
	float x2 = -x1 + m_obContentSize.width;
	float y2 = -y1 + m_obContentSize.height;

	m_sQuad.bl.vertices = vertex3(x1, y1, 0);
	m_sQuad.br.vertices = vertex3(x2, y1, 0);
	m_sQuad.tl.vertices = vertex3(x1, y2, 0);
	m_sQuad.tr.vertices = vertex3(x2, y2, 0);
}

void CC3DSprite::updateTextureCoords(CCRect rect, bool rotated)
{
	rect = CC_RECT_POINTS_TO_PIXELS(rect);

	CCTexture2D *tex = m_pobTexture;
	if (! tex)
	{
		return;
	}

	float atlasWidth = (float)tex->getPixelsWide();
	float atlasHeight = (float)tex->getPixelsHigh();

	float left, right, top, bottom;

	if (rotated)
	{
#if CC_FIX_ARTIFACTS_BY_STRECHING_TEXEL
		left    = (2*rect.origin.x+1)/(2*atlasWidth);
		right    = left+(rect.size.height*2-2)/(2*atlasWidth);
		top        = (2*rect.origin.y+1)/(2*atlasHeight);
		bottom    = top+(rect.size.width*2-2)/(2*atlasHeight);
#else
		left    = rect.origin.x/atlasWidth;
		right    = (rect.origin.x+rect.size.height) / atlasWidth;
		top        = rect.origin.y/atlasHeight;
		bottom    = (rect.origin.y+rect.size.width) / atlasHeight;
#endif // CC_FIX_ARTIFACTS_BY_STRECHING_TEXEL
		/*
		if (m_bFlipX)
		{
			CC_SWAP(top, bottom, float);
		}

		if (m_bFlipY)
		{
			CC_SWAP(left, right, float);
		}*/

		m_sQuad.bl.texCoords.u = left;
		m_sQuad.bl.texCoords.v = top;
		m_sQuad.br.texCoords.u = left;
		m_sQuad.br.texCoords.v = bottom;
		m_sQuad.tl.texCoords.u = right;
		m_sQuad.tl.texCoords.v = top;
		m_sQuad.tr.texCoords.u = right;
		m_sQuad.tr.texCoords.v = bottom;
	}
	else
	{
#if CC_FIX_ARTIFACTS_BY_STRECHING_TEXEL
		left    = (2*rect.origin.x+1)/(2*atlasWidth);
		right    = left + (rect.size.width*2-2)/(2*atlasWidth);
		top        = (2*rect.origin.y+1)/(2*atlasHeight);
		bottom    = top + (rect.size.height*2-2)/(2*atlasHeight);
#else
		left    = rect.origin.x/atlasWidth;
		right    = (rect.origin.x + rect.size.width) / atlasWidth;
		top        = rect.origin.y/atlasHeight;
		bottom    = (rect.origin.y + rect.size.height) / atlasHeight;
#endif // ! CC_FIX_ARTIFACTS_BY_STRECHING_TEXEL

		/*if(m_bFlipX)
		{
			CC_SWAP(left,right,float);
		}

		if(m_bFlipY)
		{
			CC_SWAP(top,bottom,float);
		}*/

		m_sQuad.bl.texCoords.u = left;
		m_sQuad.bl.texCoords.v = bottom;
		m_sQuad.br.texCoords.u = right;
		m_sQuad.br.texCoords.v = bottom;
		m_sQuad.tl.texCoords.u = left;
		m_sQuad.tl.texCoords.v = top;
		m_sQuad.tr.texCoords.u = right;
		m_sQuad.tr.texCoords.v = top;
	}
}

void CC3DSprite::visit( void )
{
	m_drawOrder = ++g_drawOrder;
	// quick return if not visible. children won't be drawn.
	if (!m_bVisible) return;
	kmGLPushMatrix();

	this->transform();

	CCNode* pNode = NULL;
	unsigned int i = 0;

	if(m_pChildren && m_pChildren->count() > 0)
	{
		sortAllChildren();
		// draw children zOrder < 0
		ccArray *arrayData = m_pChildren->data;
		for( ; i < arrayData->num; i++ )
		{
			pNode = (CCNode*) arrayData->arr[i];

			if ( pNode && pNode->getZOrder() < 0 )
			{
				pNode->visit();
			}
			else
			{
				break;
			}
		}
		// self draw
		this->draw();

		for( ; i < arrayData->num; i++ )
		{
			pNode = (CCNode*) arrayData->arr[i];
			if (pNode)
			{
				pNode->visit();
			}
		}
	}
	else
	{
		this->draw();
	}

	// reset for next frame
	m_uOrderOfArrival = 0;

	kmGLPopMatrix();
}

void CC3DSprite::transform()
{
	kmMat4 transfrom4x4;

	// Update Z vertex manually
	transfrom4x4.mat[14];
	//kmGLLoadIdentity()

	kmGLMultMatrix( &transfrom4x4 );

}



