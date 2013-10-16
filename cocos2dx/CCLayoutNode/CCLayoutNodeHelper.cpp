#include "CCLayoutNodeHelper.h"
#include "CCLayoutNodeConfig.h"

inline static CCPoint JsonToCCPoint(const Json::Value& json)
{
	return ccp(json["x"].asDouble(), json["y"].asDouble());
}

inline static CCSize JsonToCCSize(const Json::Value& json)
{
	return CCSizeMake(json["width"].asDouble(), json["height"].asDouble());
}

inline static ccColor3B JsonToccColor3B(const Json::Value& json)
{
	ccColor3B c = {json["r"].asInt(), json["g"].asInt(), json["b"].asInt()};
	return c;
}

inline static bool JsonTobool(const Json::Value& json)
{
	return json.asBool();
}

inline static float JsonTofloat(const Json::Value& json)
{
	return (float)json.asDouble();
}

inline static int JsonToint(const Json::Value& json)
{
	return json.asInt();
}

inline static std::string JsonTostring(const Json::Value& json)
{
	return json.asString();
}

inline static const char* JsonTocharptr(const Json::Value& json)
{
	return json.asCString();
}

inline static std::string JsonToFontname(const Json::Value& json)
{
	if (json == Json::nullValue)
	{
		return GET_TITLE_FONT;		
	}else
	{
		return GET_FONT_NAME(json.asString());
	}
	
}

inline static std::string JsonToLanguagecharptr(const Json::Value& json)
{
	return GET_LANGUAGE_CONTENT(json.asCString());
}

inline static CCNode* JsonToCCNode(const Json::Value& json)
{
	return CCLayoutNodeHelper::create(json);
}

#define SET_PROPERTY(json, getter, target, setter) \
{ \
 	const Json::Value& __var__ = json; \
 	if (__var__ != Json::nullValue) { \
	target->##setter(getter(__var__)); \
	} \
}

void CCLayoutNodeHelper::setCCNode( CCNode* node, const Json::Value& json )
{
	SET_PROPERTY(json["position"], JsonToCCPoint, node, setPosition);
	SET_PROPERTY(json["containSize"], JsonToCCSize, node, setContentSize);
	SET_PROPERTY(json["anchorPoint"], JsonToCCPoint, node, setAnchorPoint);
	SET_PROPERTY(json["rotation"], JsonTofloat, node, setRotation);
	SET_PROPERTY(json["visible"], JsonTobool, node, setVisible);
	SET_PROPERTY(json["zOrder"], JsonTobool, node, setZOrder);
	SET_PROPERTY(json["scale"]["x"], JsonTofloat, node, setScaleX);
	SET_PROPERTY(json["scale"]["y"], JsonTofloat, node, setScaleY);
}

void CCLayoutNodeHelper::setCCNodeRGBA( CCNodeRGBA* node, const Json::Value& json )
{
	SET_PROPERTY(json["color"], JsonToccColor3B, node, setColor);
	SET_PROPERTY(json["opacity"], JsonToint, node,setOpacity);
}

void CCLayoutNodeHelper::setCCSprite(CCSprite* node, const Json::Value& json)
{
	SET_PROPERTY(json["spriteFrameName"], JsonTocharptr, node, initWithSpriteFrameName);
	SET_PROPERTY(json["spriteFileName"], JsonTocharptr, node, initWithFile);
	SET_PROPERTY(json["flipX"], JsonTobool, node, setFlipX);
	SET_PROPERTY(json["flipY"], JsonTobool, node, setFlipY);
}

void CCLayoutNodeHelper::setCCScale9Sprite(CCScale9Sprite* node, const Json::Value& json)
{
	SET_PROPERTY(json["spriteFrameName"], JsonTocharptr, node, initWithSpriteFrameName);
	SET_PROPERTY(json["spriteFileName"], JsonTocharptr, node, initWithFile);
}

CCNode* CCLayoutNodeHelper::create( const Json::Value& json )
{
	std::string type = json["$type"].asString();

	if (type == "CCNode" || type.empty())
	{
		return createCCNode(json);
	}

	if (type == "CCSprite")
	{
		return createCCSprite(json);
	}

	if (type == "CCScale9Sprite")
	{
		return createCCScale9Sprite(json);
	}

	if (type == "CCLabelTTF")
	{
		return createCCLabelTTF(json);
	}

	if (type == "CCLabelTTFEX")
	{
		return createCCLabelTTFEx(json);
	}

	if (type == "CCMenuItemSprite")
	{
		return createCCMenuItemSprite(json);
	}

	if (type == "CCMenu")
	{
		return createCCMenu(json);
	}
	return NULL;
}

CCNode* CCLayoutNodeHelper::createCCNode( const Json::Value& json )
{
	CCNode* node = CCNode::create();

	setCCNode(node, json);

	return node;
}

CCSprite* CCLayoutNodeHelper::createCCSprite( const Json::Value& json )
{
	CCSprite* node = CCSprite::create();

	setCCSprite(node, json);
	setCCNodeRGBA(node, json);
	setCCNode(node, json);

	return node;
}

CCScale9Sprite* CCLayoutNodeHelper::createCCScale9Sprite(const Json::Value& json)
{
	CCScale9Sprite* node = CCScale9Sprite::create();

	setCCScale9Sprite(node, json);
	setCCNodeRGBA(node, json);
	setCCNode(node, json);

	return node;
}

CCLabelTTF* CCLayoutNodeHelper::createCCLabelTTF(const Json::Value& json)
{

	std::string text;
	if (json["text"] != Json::nullValue)
	{
		text = json["text"].asString();
	}
	if (json["languagetext"] != Json::nullValue)
	{
		text = json["languagetext"].asString();
	}

	std::string fontname = JsonToFontname(json["fontName"]);
	int fontSize = JsonToint(json["fontSize"]);

	CCLabelTTF* node = NULL;
	if (json["dmensions"] != Json::nullValue)
	{
		CCSize dmensions = JsonToCCSize(json["dmensions"]);
		CCTextAlignment align = (CCTextAlignment)json["horizontalAlignment"].asInt();
		CCVerticalTextAlignment verAlign = (CCVerticalTextAlignment)json["verticalTextAlignment"].asInt();

		node = CCLabelTTF::create(text.c_str(), fontname.c_str(), fontSize, dmensions, align, verAlign);
	}else
	{
		node = CCLabelTTF::create(text.c_str(), fontname.c_str(), fontSize );
	}

	setCCSprite(node, json);
	setCCNodeRGBA(node, json);
	setCCNode(node, json);

	return node;
}

CCLabelTTFEx* CCLayoutNodeHelper::createCCLabelTTFEx(const Json::Value& json)
{
	std::string text;
	if (json["text"] != Json::nullValue)
	{
		text = json["text"].asString();
	}
	if (json["text"] != Json::nullValue)
	{
		text = json["languagetext"].asString();
	}
	
	std::string fontname = JsonToFontname(json["fontName"]);
	int fontSize = JsonToint(json["fontSize"]);
	
	CCLabelTTFEx* node = NULL;
	if (json["dmensions"] != Json::nullValue)
	{
		CCSize dmensions = JsonToCCSize(json["dmensions"]);
		CCTextAlignment align = (CCTextAlignment)json["horizontalAlignment"].asInt();
		CCVerticalTextAlignment verAlign = (CCVerticalTextAlignment)json["verticalTextAlignment"].asInt();
		
		node = CCLabelTTFEx::labelWithString(text.c_str(), dmensions, align, fontname.c_str(), fontSize );
	}else
	{
		node = CCLabelTTFEx::labelWithString(text.c_str(), fontname.c_str(), fontSize );
	}
	
	setCCSprite(node, json);
	setCCNodeRGBA(node, json);
	setCCNode(node, json);

	return node;
}

CCMenuItemSprite* CCLayoutNodeHelper::createCCMenuItemSprite(const Json::Value& json)
{
	CCMenuItemSprite* node = CCMenuItemSprite::create(NULL,NULL);
	SET_PROPERTY(json["children"]["__NormalImage__"], JsonToCCNode, node, setNormalImage);
	SET_PROPERTY(json["children"]["__SelectedImage__"], JsonToCCNode, node, setSelectedImage);
	SET_PROPERTY(json["children"]["__DisabledImage__"], JsonToCCNode, node, setDisabledImage);

#if UIEDITOR
	setCCNodeRGBA(node, json);
#endif
	setCCNode(node, json);

	return node;
}

CCMenu* CCLayoutNodeHelper::createCCMenu(const Json::Value& json)
{
	CCMenu* menu = NULL;
	if ( json["isTopButton"].asBool() )
	{
		menu = TopButton::create();
	}else
	{
		menu = CCMenu::create();
	}
	setCCNode(menu, json);
	return menu;
}