#ifndef CCLayoutNode_h__
#define CCLayoutNode_h__

#include "../include/cocos2d.h"
#include "../lib_json/json/json.h"
using namespace cocos2d;

class CCLayoutNode : public CCNode
{
	CCDictionary* mNodesDict;
	CCLayoutNode();
	~CCLayoutNode();
public:
	static CCLayoutNode* create(const Json::Value& json);
	bool init(const Json::Value& json);
private:
	void addChildrenByJson(CCNode* node, const Json::Value& json);
	CCNode* createChild(const Json::Value& json);
};

#endif // CCLayoutNode_h__