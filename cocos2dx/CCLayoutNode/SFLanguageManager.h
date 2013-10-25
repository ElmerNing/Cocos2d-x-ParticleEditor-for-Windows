#ifndef __SFLANGUAGEMANGER_H__
#define __SFLANGUAGEMANGER_H__

#include "cocos2d.h"

using namespace cocos2d;
using namespace std;

#define GET_LANGUAGE_CONTENT(keyWord) SFLanguageManager::shareLanguageManager()->getContentByKeyWord(keyWord)

/*#define GET_GUIDE_TEXT(keyWord) SFLanguageManager::shareLanguageManager()->getGuideTextByKeyWord(keyWord)*/

typedef enum
{
	CH = 0,
	TW,
	US
}SFLanguageType;

class SFLanguage;

class SFLanguageManager : CCObject
{
public:
	SFLanguageManager(void);
	virtual ~SFLanguageManager(void);

public:
	CC_SYNTHESIZE(SFLanguageType, languge, Language);
    
    static SFLanguageManager* shareLanguageManager();
	static void purgeLanguageManager();
    
    virtual bool init();

private:
	
	CCDictionary *languageDict;

/*	LanguageDict *guideDict;*/

public:
    string getContentByKeyWord(string keyWord); // xml.keyWord,const char* formXml, const char* keyWord
// 
// 	string getGuideTextByKeyWord(string keyWord);

    void loadXMLFile(string fileName);
};

class SFLanguage : public CCObject
{
public:
    SFLanguage(){}
    virtual ~SFLanguage(){}
    CC_SYNTHESIZE(string, keyWord, KeyWord);
    CC_SYNTHESIZE(string, text, Text);
};

//class SFLanguageDict : public CCObject
//{
//public:
//    SFLanguageDict();
//    virtual ~SFLanguageDict();
//    
//    CC_SYNTHESIZE(languageDict *, _languageDict, LanguageDict);
//};
#endif
