#include "CCLayoutNodeHelper.h"

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

#define SET_PROPERTY(json, getter, target, setter) \
{ \
 	const Json::Value& __var__ = json; \
 	if (__var__ != Json::nullValue) { \
	target->##setter(getter(__var__)); \
	} \
}
// 		target->##setter(getter(__var__)); \ 
// 	}


void CCLayoutNodeHelper::setCCNode( CCNode* node, const Json::Value& json )
{
// 
// 	public CCPoint postion = null;
// 	public CCPoint anchorPoint = null;
// 	public CCPoint scale = null;
// 	public float rotation = 0;
// 	public bool visible = true;
// 	public int zOrder = 0;

	SET_PROPERTY(json["position"], JsonToCCPoint, node, setPosition);
	SET_PROPERTY(json["containSize"], JsonToCCSize, node, setContentSize);
	SET_PROPERTY(json["anchorPoint"], JsonToCCPoint, node, setAnchorPoint);
	SET_PROPERTY(json["rotation"], JsonTofloat, node, setRotation);
	SET_PROPERTY(json["visible"], JsonTobool, node, setRotation);
	SET_PROPERTY(json["zOrder"], JsonTobool, node, setZOrder);
	SET_PROPERTY(json["scale"]["x"], JsonTofloat, node, setScaleX);
	SET_PROPERTY(json["scale"]["y"], JsonTofloat, node, setScaleX);
}

void CCLayoutNodeHelper::setCCNodeRGBA( CCNodeRGBA* node, const Json::Value& json )
{
// 	public CCColor3B color = null;
// 	public bool cascadeOpacityEnabled = false;
// 	public bool cascadeColorEnabled = false;
// 	public byte opacity = 255;

	SET_PROPERTY(json["color"], JsonToccColor3B, node, setColor);
	SET_PROPERTY(json["cascadeOpacityEnabled"], JsonTobool, node, setCascadeColorEnabled);
	SET_PROPERTY(json["cascadeOpacityEnabled"], JsonTobool, node, setCascadeOpacityEnabled);
}

void CCLayoutNodeHelper::setCCSprite(CCSprite* node, const Json::Value& json)
{
// 	public string spriteFrameName = null;
// 	public string spriteFileName = null;
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


