#include "ExportAPI.h"

//this file will only be included in Win32
#include "cocos2d.h"
#include "AppDelegate.h"
#include "HelloWorldScene.h"
#include "lib_json/json/json.h"
#include "CCLayoutNode/CCLayoutNode.h"
#include "CCLayoutNode/SFLanguageManager.h"
#include "CCLayoutNode/SFFontManager.h"

extern "C"
{
	MEDUSA_EXPORT_API bool MInitializeApplication( HWND hwnd )
	{

 		cocos2d::CCEGLView::SetParentHwnd(hwnd);

		// create the application instance
		AppDelegate app;


		CCEGLView* eglView = CCEGLView::sharedOpenGLView();
		eglView->setViewName("HelloCpp");
		eglView->setFrameSize(640, 960);
		// The resolution of ipad3 is very large. In general, PC's resolution is smaller than it.
		// So we need to invoke 'setFrameZoomFactor'(only valid on desktop(win32, mac, linux)) to make the window smaller.
		eglView->setFrameZoomFactor(1.f);


		CCApplication::sharedApplication()->run();
		return true;
	}


	MEDUSA_EXPORT_API bool MGameCleanUp()
	{

		cocos2d::CCEGLView::Destroy();

		cocos2d::CCDirector::sharedDirector()->end();

		return true;
	}

	MEDUSA_EXPORT_API bool MGameLoop( float interval )
	{
		cocos2d::CCDirector::sharedDirector()->mainLoop();
		return true;
	}

	MEDUSA_EXPORT_API bool MAddSpriteFramesWithFile(char* path)
	{
		CCSpriteFrameCache::sharedSpriteFrameCache()->addSpriteFramesWithFile(path);
		return true;
	}

	MEDUSA_EXPORT_API bool MAddSearchPath(char* path)
	{
		CCFileUtils::sharedFileUtils()->addSearchPath(path);
		return true;
	}

	MEDUSA_EXPORT_API bool MSetResourceDir(char* path)
	{
		//search path
		CCFileUtils::sharedFileUtils()->addSearchPath(path);

		//language
		SFLanguageManager::shareLanguageManager()->loadXMLFile("language/language.xml");

		//font
		SFFontManager::sharedSFFontManager();
		return true;
	}

	MEDUSA_EXPORT_API bool MRemoveSpriteFrames()
	{
		CCSpriteFrameCache::sharedSpriteFrameCache()->removeSpriteFrames();
		return true;
	}

	MEDUSA_EXPORT_API bool MUiChanged(char* json)
	{
		Json::Value root;
		Json::Reader reader;
		reader.parse(json, root, false);

		HelloWorld::ChangeUi( CCLayoutNode::create(root) );

		return true;
	}

	MEDUSA_EXPORT_API bool MUiPosition(char* name, int& x, int& y)
	{
		CCArray* arr = HelloWorld::mUiNode->getChildren();
		CCObject* object;
		CCLayoutNode* node = NULL;
		CCARRAY_FOREACH(arr, object)
		{
			node = dynamic_cast<CCLayoutNode*>(object);
			if (node != NULL)
			{
				CCNode* child = node->getChildByName(name);
				if (child == NULL)
					continue;
				
				CCPoint point = child->getParent()->convertToWorldSpace(ccp(0,0));
				x = point.x;
				y = point.y;

				return true;
			}
		}

		return false;
	}

}

