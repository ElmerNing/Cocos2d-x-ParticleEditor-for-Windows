#include "CCLayoutNode.h"
#include "CCLayoutNodeHelper.h"

CCLayoutNode::CCLayoutNode()
{
	mNodesDict = CCDictionary::create();
	mNodesDict->retain();
}

CCLayoutNode::~CCLayoutNode()
{
	CC_SAFE_RELEASE(mNodesDict);
}

CCLayoutNode* CCLayoutNode::create( const Json::Value& json )
{
	CCLayoutNode* ret = new CCLayoutNode();
	if (ret && ret->init(json))
	{
		ret->autorelease();
		return ret;
	}else
	{
		CC_SAFE_DELETE(ret);
		return ret;
	}
}

bool CCLayoutNode::init( const Json::Value& json )
{
	//mNodesDict->removeAllObjects();
	//removeAllChildren();

	CCLayoutNodeHelper::setCCNode(this, json);

	addChildrenByJson(this, json["children"]);

	return true;
}

void CCLayoutNode::addChildrenByJson(CCNode* node, const Json::Value& json)
{
	Json::ValueIterator it = json.begin();
	for (;it != json.end(); it++)
	{
		std::string name = it.memberName();
		if (!name.empty())
		{
			CCNode* child = createChild(*it);
			if (child)
			{
				node->addChild(child);
			}
			
		}
		
	}	//createChild(it->key());
	
}

CCNode* CCLayoutNode::createChild(const Json::Value& json)
{
	CCNode* node = CCLayoutNodeHelper::create(json);
	if (node && json["children"] != Json::nullValue)
	{
		addChildrenByJson(node, json["children"]);
	}
	return node;
}


