#include "SFLanguageManager.h"
#include "../support/tinyxml2/tinyxml2.h"
#include <sstream>

using namespace tinyxml2;

static SFLanguageManager *languageManager = NULL;

SFLanguageManager::SFLanguageManager(void)
	: languageDict(NULL)
/*	, guideDict(NULL)*/
{
}


SFLanguageManager::~SFLanguageManager(void)
{
    CC_SAFE_RELEASE_NULL(languageDict);
/*	CC_SAFE_RELEASE_NULL(guideDict);*/
}

void SFLanguageManager::loadXMLFile(string fileName)
{
    tinyxml2::XMLDocument doc;
  
    string fullPath = CCFileUtils::sharedFileUtils()->fullPathForFilename(fileName.c_str());
	//---------------------------------modified by luowenjian android needed
	//doc.LoadFile(fullPath);

	unsigned long size;
	char *pFileContent = (char*)CCFileUtils::sharedFileUtils()->getFileData( fullPath.c_str() , "r", &size);
	//CCLOG("========");
	doc.Parse(pFileContent);
  //===================================modified by luowenjian android needed end
    tinyxml2::XMLElement *rootElement = doc.RootElement();
    
    tinyxml2::XMLElement *viewElement = rootElement->FirstChildElement("view");
    while (viewElement) {
        tinyxml2::XMLElement *textElement = viewElement->FirstChildElement("text");
        while(textElement)
        {
            SFLanguage *lang = new SFLanguage();
            lang->autorelease();
            string keyWord = textElement->Attribute("keyWord");
            lang->setKeyWord(keyWord);
            
            tinyxml2::XMLElement *contentElement;
            if (getLanguage() == CH) {
                contentElement = textElement->FirstChildElement("ch");
            }else if(getLanguage() == TW){
                contentElement = textElement->FirstChildElement("tw");
            }else {
                contentElement = textElement->FirstChildElement("us");
            }
            string text = contentElement->GetText();
            lang->setText(text);
            
            //languageArray->addObject(lang);
			languageDict->setObject(lang, keyWord);
            
            textElement = textElement->NextSiblingElement();
        }
        
        viewElement = viewElement->NextSiblingElement();
    }
}

SFLanguageManager* SFLanguageManager::shareLanguageManager()
{
    if(languageManager == NULL)
    {
        languageManager = new SFLanguageManager();
        if (languageManager != NULL && languageManager->init()) {
            return languageManager;
        }
        else 
        {
            delete languageManager;
            languageManager = NULL;
            return NULL;
        }
    }
    
    return languageManager;
}

void SFLanguageManager::purgeLanguageManager()
{
	CC_SAFE_DELETE(languageManager);
}

bool SFLanguageManager::init()
{
    this->setLanguage(CH);
    
    languageDict = CCDictionary::create();
	languageDict->retain();
/*	guideDict    = new LanguageDict();*/
	loadXMLFile("language/language.xml");
	//loadXMLFile("language/userguide", guideDict);
    
    return true;
}

string SFLanguageManager::getContentByKeyWord(string keyWord)
{
    SFLanguage *pLanguage = (SFLanguage*)languageDict->objectForKey(keyWord);

    if (pLanguage != NULL) 
	{
		return pLanguage->getText();
    }
	return "\0";
}

// string SFLanguageManager::getGuideTextByKeyWord(string keyWord)
// {
// 	SFLanguage *pLanguage = guideDict->objectForKey(keyWord);
// 
// 	if (pLanguage != NULL) 
// 	{
// 		return pLanguage->getText();
// 	}
// 	return "\0";
// }
