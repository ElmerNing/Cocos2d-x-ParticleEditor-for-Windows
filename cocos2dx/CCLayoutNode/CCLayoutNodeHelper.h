#ifndef CCLayoutNodeHelper_h__
#define CCLayoutNodeHelper_h__

#include "../include/cocos2d.h"

#include "../lib_json/json/json.h"
using namespace cocos2d;

class CCLayoutNodeHelper 
{
public:
	static void setCCNode(CCNode* node, const Json::Value& json);
	static void setCCNodeRGBA( CCNodeRGBA* node, const Json::Value& json );
	static void setCCSprite(CCSprite* node, const Json::Value& json);

	static CCNode* create(const Json::Value& json);
	static CCNode* createCCNode(const Json::Value& json);
	static CCSprite* createCCSprite(const Json::Value& json);
};
#endif // CCLayoutNodeHelper_h__