#ifndef __SFFONTMANAGER_H__
#define __SFFONTMANAGER_H__

#include "cocos2d.h"

using namespace cocos2d;
using namespace std;

#define GET_FONT_NAME(alias) SFFontManager::sharedSFFontManager()->getFontName(alias).c_str()
#define GET_FONT_COLOR(alias) SFFontManager::sharedSFFontManager()->getFontColor(alias)
#define GET_FONT_SIZE(alias) SFFontManager::sharedSFFontManager()->getFontSize(alias)
#define GET_TITLE_FONT SFFontManager::sharedSFFontManager()->getTitleFont().c_str()
#define ccColor(value) ccc3((0xFF)&(value>>16), (0xFF)&(value>>8), (0xFF)&value)

class SFFontName : public CCObject {
public:
    SFFontName(){}
    virtual ~SFFontName(){}
    CC_SYNTHESIZE(string, alias_, Alias);
    CC_SYNTHESIZE(string, name_, Name);
};

class SFFontSize : public CCObject {
public:
    CC_SYNTHESIZE(string, alias_, Alias);
    CC_SYNTHESIZE(int, size_, Size);
};

class SFFontColor : public CCObject {
public:
    CC_SYNTHESIZE(string, alias_, Alias);
    CC_SYNTHESIZE(ccColor3B, color_, Color);
};

class SFFontManager : CCObject
{
public:
	SFFontManager(void);
	virtual ~SFFontManager(void);

public:
	static SFFontManager* sharedSFFontManager();
	static void purgeFontManager();
	virtual bool init();

public:
    std::string getFontName(const char* alias);
	std::string getTitleFont();
    float getFontSize(const char* alias);
    ccColor3B getFontColor(const char* alias);

private:
    int convertFromHex(string hex);
private:
    CCArray *fontNameArray;
    CCArray *fontSizeArray;
    CCArray *fontColorArray;
};

#endif

