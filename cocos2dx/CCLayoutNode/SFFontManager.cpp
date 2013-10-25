#include "SFFontManager.h"
#include "../support/tinyxml2/tinyxml2.h"

using namespace tinyxml2;

static SFFontManager *theMgr = NULL;

SFFontManager::SFFontManager(void)
	: fontNameArray(NULL)
	, fontSizeArray(NULL)
	, fontColorArray(NULL)
{
}


SFFontManager::~SFFontManager(void)
{
	CC_SAFE_RELEASE_NULL(fontNameArray);
	CC_SAFE_RELEASE_NULL(fontSizeArray);
	CC_SAFE_RELEASE_NULL(fontColorArray);
}

SFFontManager* SFFontManager::sharedSFFontManager()
{
	if (theMgr == NULL)
	{
		theMgr = new SFFontManager();
		if (theMgr != NULL && theMgr->init())
		{
			return theMgr;
		}
		else
		{
			delete theMgr;
			theMgr = NULL;
			return NULL;
		}
	}

	return theMgr;
}

void SFFontManager::purgeFontManager()
{
	CC_SAFE_DELETE(theMgr);
}

bool SFFontManager::init()
{
    tinyxml2::XMLDocument doc;
    
	//-------------------------------modified by luowenjian android needed
    //doc.LoadFile("font.xml");
    string fullPath = CCFileUtils::sharedFileUtils()->fullPathForFilename("font.xml");
    //doc.LoadFile(fullPath);

	unsigned long size;
	char *pFileContent = (char*)CCFileUtils::sharedFileUtils()->getFileData( fullPath.c_str() , "r", &size);
	doc.Parse(pFileContent);
	//==============================modified by luowenjian android needed end

    tinyxml2::XMLElement *rootElement = doc.RootElement();
    
	fontNameArray = CCArray::createWithCapacity(20);
	fontNameArray->retain();
    tinyxml2::XMLElement *namesElement = rootElement->FirstChildElement("names");
    tinyxml2::XMLElement *nameElement = namesElement->FirstChildElement("name");
    while(nameElement)
    {
        SFFontName *fontName = new SFFontName();
        fontName->autorelease();
        string alias = nameElement->Attribute("alias");
        fontName->setAlias(alias);
        string name = nameElement->GetText();
        fontName->setName(name);
        
        fontNameArray->addObject(fontName);
        
        nameElement = nameElement->NextSiblingElement();
    }

	fontSizeArray = CCArray::createWithCapacity(20);
	fontSizeArray->retain();
    tinyxml2::XMLElement *sizesElement = rootElement->FirstChildElement("sizes");
    tinyxml2::XMLElement *sizeElement = sizesElement->FirstChildElement("size");
    while(sizeElement)
    {
        SFFontSize *fontSize = new SFFontSize();
        fontSize->autorelease();
        string alias = sizeElement->Attribute("alias");
        fontSize->setAlias(alias);
        const char *temp =sizeElement->GetText();
        CCString *str = CCString::create(temp);
        fontSize->setSize(str->intValue());
        fontSizeArray->addObject(fontSize);
        sizeElement = sizeElement->NextSiblingElement();
    }
    
	fontColorArray = CCArray::createWithCapacity(20);
	fontColorArray->retain();
    tinyxml2::XMLElement *colorsElement = rootElement->FirstChildElement("colors");
    tinyxml2::XMLElement *colorElement = colorsElement->FirstChildElement("color");
    while(colorElement)
    {
        SFFontColor *fontColor = new SFFontColor();
        fontColor->autorelease();
        string alias = colorElement->Attribute("alias");
        fontColor->setAlias(alias);
        string strColor = colorElement->GetText();
        string strR = strColor.substr(0, 2);
        string strG = strColor.substr(2, 2);
        string strB = strColor.substr(4, 2);
        ccColor3B color = {convertFromHex(strR),convertFromHex(strG),convertFromHex(strB)};
        fontColor->setColor(color);
        fontColorArray->addObject(fontColor);
        colorElement = colorElement->NextSiblingElement();
    }
    
	return true;
}

std::string SFFontManager::getFontName(const char *alias)
{
    CCObject *obj;
    CCARRAY_FOREACH(fontNameArray, obj)
    {
        SFFontName *fontName = (SFFontName *)(obj);
        if (strcmp(alias, fontName->getAlias().c_str()) == 0)
        {
            return fontName->getName();   
        }
    }
    return "\0";
}

std::string SFFontManager::getTitleFont()
{
#if (CC_TARGET_PLATFORM == CC_PLATFORM_ANDROID)
	return "fzy4k.ttf";
#elif(CC_TARGET_PLATFORM == CC_PLATFORM_IOS)
    return getFontName("font4");
#endif
	return "DFPHaiBaoW12-GB";
}

float SFFontManager::getFontSize(const char *alias)
{
    CCObject *obj;
    CCARRAY_FOREACH(fontSizeArray, obj)
    {
        SFFontSize *fontSize = (SFFontSize *)obj;
        if (strcmp(alias, fontSize->getAlias().c_str()) == 0)
        {
			return (float)fontSize->getSize();
        }
    }
    return NULL;
}

ccColor3B SFFontManager::getFontColor(const char *alias)
{
    CCObject *obj;
    CCARRAY_FOREACH(fontColorArray, obj)
    {
        SFFontColor *fontColor = (SFFontColor *)obj;
        if (strcmp(alias, fontColor->getAlias().c_str()) == 0)
        {
            return fontColor->getColor();
        }
    }
    return ccBLACK;
}

int SFFontManager::convertFromHex(string hex)
{
    int value = 0;
    int a = 0;
    int b = hex.length() - 1;
    for (; b >= 0; a++, b--)
    {
        if (hex[b] >= '0' && hex[b] <= '9')
        {
            value += (hex[b] - '0') * (1 << (a * 4));
        }
        else
        {
            switch (hex[b])
            {
                case 'A':
                case 'a':
                    value += 10 * (1 << (a * 4));
                    break;
                    
                case 'B':
                case 'b':
                    value += 11 * (1 << (a * 4));
                    break;
                    
                case 'C':
                case 'c':
                    value += 12 * (1 << (a * 4));
                    break;
                    
                case 'D':
                case 'd':
                    value += 13 * (1 << (a * 4));
                    break;
                    
                case 'E':
                case 'e':
                    value += 14 * (1 << (a * 4));
                    break;
                    
                case 'F':
                case 'f':
                    value += 15 * (1 << (a * 4));
                    break;
                    
                default:
                    break;
            }
        }
    }
    
    return value;
}


