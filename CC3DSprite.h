#pragma once

#include "cocos2d.h"
USING_NS_CC;

class CC3DSprite : public CCNode
{
public:	
	CC3DSprite();
	~CC3DSprite();
	CC3DSprite* createWithTexture(CCTexture2D *pTexture);
	CC3DSprite* createWithTexture(CCTexture2D *pTexture, const CCRect& rect);
	CC3DSprite* create(const char *pszFileName);
	CC3DSprite* create(const char *pszFileName, const CCRect& rect);
	CC3DSprite* create();
	CC3DSprite* createWithSpriteFrame(CCSpriteFrame *pSpriteFrame);
	CC3DSprite* createWithSpriteFrameName(const char *pszSpriteFrameName);
	bool init(void);
	bool initWithTexture(CCTexture2D *pTexture, const CCRect& rect, bool rotated);
	bool initWithTexture(CCTexture2D *pTexture, const CCRect& rect);
	bool initWithTexture(CCTexture2D *pTexture);
	bool initWithFile(const char *pszFilename);
	bool initWithFile(const char *pszFilename, const CCRect& rect);
	bool initWithSpriteFrame(CCSpriteFrame *pSpriteFrame);
	bool initWithSpriteFrameName(const char *pszSpriteFrameName);
	void setDisplayFrame(CCSpriteFrame *pNewFrame);
	void setTextureRect(const CCRect& rect, bool rotated);
	void setTexture(CCTexture2D *texture);
	CCTexture2D* getTexture(void);

	virtual void visit(void);
	void transform();

private:
	void updateTextureCoords(CCRect rect, bool rotated);
	void updateVertexRect();
private:
	ccV3F_C4B_T2F_Quad m_sQuad;					/// vertex, color, coord

	CCTexture2D*       m_pobTexture;            /// CCTexture2D object that is used to render the sprite
	CCRect			   m_obTextureRect;			/// the rect used in m_pobTexture
	bool			   m_bRectRotated;			/// if the m_obTextureRect is rotated

};
