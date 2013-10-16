/****************************************************************************
Copyright (c) 2010-2011 cocos2d-x.org
Copyright (c) 2008-2010 Ricardo Quesada

http://www.cocos2d-x.org

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
****************************************************************************/
#include "CCLabelTTFEx.h"
#include "CCDirector.h"

namespace cocos2d{
	//
	//CCLabelTTFEx
	//
    CCLabelTTFEx::CCLabelTTFEx()
        : m_eAlignment(kCCTextAlignmentCenter)
        , m_pFontName(NULL)
        , m_fFontSize(0.0)
        , m_pString("\0")
        , isBlink(false)
		, m_renderTexture(NULL)
    {
    }

    CCLabelTTFEx::~CCLabelTTFEx()
    {
        
		CC_SAFE_DELETE(m_pFontName);      
    }

	CCLabelTTFEx * CCLabelTTFEx::labelWithString(const char *label, const CCSize& dimensions, CCTextAlignment alignment, const char *fontName, float fontSize)
	{
		CCLabelTTFEx *pRet = new CCLabelTTFEx();
		if(pRet && pRet->initWithString(label, dimensions, alignment, fontName, fontSize))
		{
			pRet->autorelease();
			return pRet;
		}
		CC_SAFE_DELETE(pRet);
		return NULL;
	}
	CCLabelTTFEx * CCLabelTTFEx::labelWithString(const char *label, const char *fontName, float fontSize)
	{
		CCLabelTTFEx *pRet = new CCLabelTTFEx();
		if(pRet && pRet->initWithString(label, fontName, fontSize))
		{
			pRet->autorelease();
			return pRet;
		}
		CC_SAFE_DELETE(pRet);
		return NULL;
	}

	bool CCLabelTTFEx::initWithString(const char *label, const CCSize& dimensions, CCTextAlignment alignment, const char *fontName, float fontSize)
	{
		CCAssert(label != NULL, "");
		if (CCSprite::init())
		{
			m_tDimensions = CCSizeMake( dimensions.width * CC_CONTENT_SCALE_FACTOR(), dimensions.height * CC_CONTENT_SCALE_FACTOR() );
			m_eAlignment = alignment;

            if (m_pFontName)
            {
                delete m_pFontName;
                m_pFontName = NULL;
            }
            m_pFontName = new std::string(fontName);

			m_fFontSize = fontSize * CC_CONTENT_SCALE_FACTOR();
			this->setString(label);
			return true;
		}
		return false;
	}
	bool CCLabelTTFEx::initWithString(const char *label, const char *fontName, float fontSize)
	{
		CCAssert(label != NULL, "");
		if (CCSprite::init())
		{
			m_tDimensions = CCSizeZero;

            if (m_pFontName)
            {
                delete m_pFontName;
                m_pFontName = NULL;
            }
            m_pFontName = new std::string(fontName);

			m_fFontSize = fontSize * CC_CONTENT_SCALE_FACTOR();
			this->setString(label);
			return true;
		}
		return false;
	}
	void CCLabelTTFEx::setString(const char *label)
	{
		if (m_pString.compare(label))
		{
			if (m_renderTexture) {
				removeChild(m_renderTexture, true);
			}

			m_pString = label;

			CCTexture2D *texture = new CCTexture2D();
			//texture->initWithString(label, m_tDimensions, m_eAlignment, kCCVerticalTextAlignmentCenter, m_pFontName->c_str(), m_fFontSize);
			texture->initWithString(label, m_pFontName->c_str(), m_fFontSize, m_tDimensions, kCCTextAlignmentCenter, kCCVerticalTextAlignmentCenter );
			this->setTexture(texture);
			texture->release();

			CCRect rect = CCRectZero;
			rect.size = m_pobTexture->getContentSize();
			this->setTextureRect(rect);
		}
	}

    void CCLabelTTFEx::setNewString(void)
    {
        setString(newString_.c_str());
        this->setColor(color_);
        this->setOpacity(255);
        isBlink = false;
    }
    
    void CCLabelTTFEx::setStringAndBlink(const char *label)
    {
        if (label != getString()) {
            CCLOG("setStringAndBlink 1");
            newString_ = std::string(label);
            if (isBlink == false) {
                CCLOG("is blink 1");
                color_ = this->getColor();
            }
			CCBlink *blink = CCBlink::create(1.5f, 15);
            CCCallFunc *callBack = CCCallFunc::create(this, callfunc_selector(CCLabelTTFEx::setNewString));
            this->runAction(CCSequence::create(blink, callBack, NULL));
            isBlink = true;
        }
        else {
            setString(label);
        }
    }
    
	const char* CCLabelTTFEx::getString(void)
	{
		return m_pString.c_str();
	}

	char * CCLabelTTFEx::description()
	{
		char *ret = new char[100] ;
		sprintf(ret, "<CCLabelTTFEx | FontName = %s, FontSize = %.1f>", m_pFontName->c_str(), m_fFontSize);
		return ret;
	}
    
    // 鎻忚竟 鍙傛暟涓€锛氳竟澶у皬(寤鸿1鍒?)  鍙傛暟浜岋細杈圭殑棰滆壊
    void CCLabelTTFEx::setStroke(float size,ccColor3B color)
    {
		if (m_pString.empty()) return;

        if (m_renderTexture) {
            removeChild(m_renderTexture, true);
        }
        
        m_lineWidth = size;
        m_lineColor = color;
        
        CCSize labelSize = getTexture()->getContentSize();
        CCPoint labelAnchorPoint = getAnchorPoint();
        float w = labelSize.width+m_lineWidth*2;
        float h = labelSize.height+m_lineWidth*2;
        CCRenderTexture* renderRexture = CCRenderTexture::create((int)w, (int)h);
        
        CCPoint originalPos = getPosition();
        ccColor3B originalColor = getColor();
        setColor(color);
        ccBlendFunc originalBlend =getBlendFunc();

		ccBlendFunc bf = { GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA };
		setBlendFunc(bf);
        
        float moveX = labelSize.width* (labelAnchorPoint.x-0.5f);
        float moveY = labelSize.height* (labelAnchorPoint.y-0.5f);
        
        float X = labelSize.width*0.5f + m_lineWidth + moveX;
        float Y = labelSize.height*0.5f + m_lineWidth + moveY;
        
        CCPoint linePos = CCPoint(X,Y);
        
        renderRexture->begin();
        for (int i=0; i<360; i+=30)
        {
			setPosition(CCPoint(linePos.x + sin(CC_DEGREES_TO_RADIANS(i))*m_lineWidth,linePos.y+cos(CC_DEGREES_TO_RADIANS(i))*m_lineWidth));
            visit();
        }
        
        renderRexture->end();
        setAnchorPoint(labelAnchorPoint);
        setPosition(originalPos);
        setColor(originalColor);
        setBlendFunc(originalBlend);
        
        CCPoint strokePosition = CCPoint(labelSize.width/2,labelSize.height/2);
        renderRexture->setPosition(strokePosition);
        addChild(renderRexture,-1);
        m_renderTexture = renderRexture;
    }
    
    void CCLabelTTFEx::removeStroke()
    {
        // ..delect CCRenderTexture
        
    }
    
    void CCLabelTTFEx::setUnderline()
    {
        /*
        if (m_TextureUnderline) {
            removeChild(m_TextureUnderline, true);
        }
        
        m_lineWidth = 1;
        m_lineColor = getColor();
        
        CCSize labelSize = getTexture()->getContentSize();
        CCPoint labelAnchorPoint = getAnchorPoint();
        int w = labelSize.width+m_lineWidth*2;
        int h = labelSize.height+m_lineWidth*2;
        CCRenderTexture* renderRexture = CCRenderTexture::renderTextureWithWidthAndHeight(w,h);
        
        CCPoint originalPos = getPosition();
        ccColor3B originalColor = getColor();
        setColor(getColor());
        ccBlendFunc originalBlend =getBlendFunc();
        setBlendFunc((ccBlendFunc) { GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA });
        
        float moveX = labelSize.width* (labelAnchorPoint.x-0.5);
        float moveY = labelSize.height* (labelAnchorPoint.y-0.5);
        
        float X = labelSize.width*0.5 + m_lineWidth + moveX;
        float Y = labelSize.height*0.5+ m_lineWidth + moveY;
        
        CCPoint linePos = CCPoint(X,Y);
                
        renderRexture->begin();
        for (int i = -2 ; i<3 ;i++) {
            setPosition(CCPoint(linePos.x + i*0.5,linePos.y ));
            visit();
        }

        renderRexture->end();
        renderRexture->setScaleY(0.1);
        renderRexture->set
        setAnchorPoint(labelAnchorPoint);
        setPosition(originalPos);
        setColor(originalColor);
        setBlendFunc(originalBlend);
        
        CCPoint strokePosition = CCPoint(labelSize.width/2,0);
        renderRexture->setPosition(strokePosition);
        addChild(renderRexture,-1);
        m_TextureUnderline = renderRexture;
         */
        CCLabelTTFEx* underlineTemp = (CCLabelTTFEx *)this->getChildByTag(underlinetag);
        if(underlineTemp){
            this->removeChildByTag(underlinetag, true);
        }
        
        CCSize labelSize = getTexture()->getContentSize();
        CCLabelTTFEx *underline = CCLabelTTFEx::labelWithString("_","Verdana-Bold" , 5);
        float ScaleRate = labelSize.width / underline->getContentSize().width ;
        underline->setScaleX(ScaleRate);
        underline->setColor(getColor());
        underline->setTag(underlinetag);
        underline->getTexture()->setAntiAliasTexParameters();
        underline->setPosition(ccp(labelSize.width/2,2));
        addChild(underline,-1);
    }
    
    void CCLabelTTFEx::delUnderline()
    {
        CCLabelTTFEx* underlineTemp = (CCLabelTTFEx *)this->getChildByTag(underlinetag);
        if(underlineTemp){
            this->removeChildByTag(underlinetag, true);
        }
    }

	void CCLabelTTFEx::setFontSize( float fontSize )
	{
		if (m_fFontSize != fontSize)
		{
			m_fFontSize = fontSize;

			// Force update
			if (m_pString.size() > 0)
			{
				CCTexture2D *texture = new CCTexture2D();
				//texture->initWithString(m_pString.c_str(), m_tDimensions, m_eAlignment, kCCVerticalTextAlignmentCenter, m_pFontName->c_str(), m_fFontSize);
				texture->initWithString(m_pString.c_str(), m_pFontName->c_str(), m_fFontSize, m_tDimensions, kCCTextAlignmentCenter, kCCVerticalTextAlignmentCenter );
				this->setTexture(texture);
				texture->release();

				CCRect rect = CCRectZero;
				rect.size = m_pobTexture->getContentSize();
				this->setTextureRect(rect);
			}
		}
	}

}// namespace cocos2d
