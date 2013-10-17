#ifndef CCLayoutNodeHelper_h__
#define CCLayoutNodeHelper_h__

#include "../include/cocos2d.h"

#include "CCLayoutNodeConfig.h"

using namespace cocos2d;

class CCLayoutNodeHelper 
{
public:
	static void setCCNode(CCNode* node, const Json::Value& json);
	static void setCCNodeRGBA( CCNodeRGBA* node, const Json::Value& json );
	static void setCCSprite(CCSprite* node, const Json::Value& json);
	static void setCCScale9Sprite(CCScale9Sprite* node, const Json::Value& json);
	static void setCCLabelTTF(CCLabelTTF* node, const Json::Value& json);

	static CCNode* create(const Json::Value& json);
	static CCNode* createCCNode(const Json::Value& json);
	static CCSprite* createCCSprite(const Json::Value& json);
	static CCScale9Sprite* createCCScale9Sprite(const Json::Value& json);
	static CCLabelTTF* createCCLabelTTF(const Json::Value& json);
	static CCLabelTTFEx* createCCLabelTTFEx(const Json::Value& json);
	static CCMenuItemSprite* createCCMenuItemSprite(const Json::Value& json);
	static CCMenu* createCCMenu(const Json::Value& json);
};
#endif // CCLayoutNodeHelper_h__