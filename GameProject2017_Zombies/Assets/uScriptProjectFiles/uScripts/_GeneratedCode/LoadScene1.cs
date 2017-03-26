//uScript Generated Code - Build 1.0.2969
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Untitled", "")]
public class LoadScene1 : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   uScript_GUI thisScriptsOnGuiListener = null; 
   bool m_RegisteredForEvents = false;
   delegate void ContinueExecution();
   ContinueExecution m_ContinueExecution;
   bool m_Breakpoint = false;
   const int MaxRelayCallCount = 1000;
   int relayCallCount = 0;
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   UnityEngine.GameObject local_3_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_3_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_5_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_5_UnityEngine_GameObject_previous = null;
   System.String local_StartAnim_System_String = "StartAnim";
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_LoadLevel logic_uScriptAct_LoadLevel_uScriptAct_LoadLevel_0 = new uScriptAct_LoadLevel( );
   System.String logic_uScriptAct_LoadLevel_name_0 = "TryToFixBugScene1";
   System.Boolean logic_uScriptAct_LoadLevel_destroyOtherObjects_0 = (bool) true;
   System.Boolean logic_uScriptAct_LoadLevel_blockUntilLoaded_0 = (bool) true;
   bool logic_uScriptAct_LoadLevel_Out_0 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_2 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_2 = (float) 1;
   System.Boolean logic_uScriptAct_Delay_SingleFrame_2 = (bool) false;
   bool logic_uScriptAct_Delay_Immediate_2 = true;
   bool logic_uScriptAct_Delay_AfterDelay_2 = true;
   bool logic_uScriptAct_Delay_Stopped_2 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_2 = false;
   
   //event nodes
   
   //property nodes
   
   //method nodes
   System.String method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_stateName_1 = "";
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_3_UnityEngine_GameObject = GameObject.Find( "Canvas" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_5_UnityEngine_GameObject = GameObject.Find( "Start" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_5_UnityEngine_GameObject_previous )
         {
            {
               uScript_Button component = local_5_UnityEngine_GameObject_previous.GetComponent<uScript_Button>();
               if ( null != component )
               {
                  component.OnButtonClick -= Instance_OnButtonClick_4;
               }
            }
         }
         
         local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_5_UnityEngine_GameObject )
         {
            {
               uScript_Button component = local_5_UnityEngine_GameObject.GetComponent<uScript_Button>();
               if ( null == component )
               {
                  component = local_5_UnityEngine_GameObject.AddComponent<uScript_Button>();
               }
               if ( null != component )
               {
                  component.OnButtonClick += Instance_OnButtonClick_4;
               }
            }
         }
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_5_UnityEngine_GameObject_previous )
         {
            {
               uScript_Button component = local_5_UnityEngine_GameObject_previous.GetComponent<uScript_Button>();
               if ( null != component )
               {
                  component.OnButtonClick -= Instance_OnButtonClick_4;
               }
            }
         }
         
         local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_5_UnityEngine_GameObject )
         {
            {
               uScript_Button component = local_5_UnityEngine_GameObject.GetComponent<uScript_Button>();
               if ( null == component )
               {
                  component = local_5_UnityEngine_GameObject.AddComponent<uScript_Button>();
               }
               if ( null != component )
               {
                  component.OnButtonClick += Instance_OnButtonClick_4;
               }
            }
         }
      }
   }
   
   void SyncEventListeners( )
   {
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != local_5_UnityEngine_GameObject )
      {
         {
            uScript_Button component = local_5_UnityEngine_GameObject.GetComponent<uScript_Button>();
            if ( null != component )
            {
               component.OnButtonClick -= Instance_OnButtonClick_4;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_LoadLevel_uScriptAct_LoadLevel_0.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_2.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_LoadLevel_uScriptAct_LoadLevel_0.Loaded += uScriptAct_LoadLevel_Loaded_0;
   }
   
   public void Start()
   {
      SyncUnityHooks( );
      m_RegisteredForEvents = true;
      
   }
   
   public void OnEnable()
   {
      RegisterForUnityHooks( );
      m_RegisteredForEvents = true;
   }
   
   public void OnDisable()
   {
      UnregisterEventListeners( );
      m_RegisteredForEvents = false;
   }
   
   public void Update()
   {
      //reset each Update, and increments each method call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      if ( null != m_ContinueExecution )
      {
         ContinueExecution continueEx = m_ContinueExecution;
         m_ContinueExecution = null;
         m_Breakpoint = false;
         continueEx( );
         return;
      }
      UpdateEditorValues( );
      
      //other scripts might have added GameObjects with event scripts
      //so we need to verify all our event listeners are registered
      SyncEventListeners( );
      
      logic_uScriptAct_LoadLevel_uScriptAct_LoadLevel_0.Update( );
      if (true == logic_uScriptAct_Delay_DrivenDelay_2)
      {
         Relay_DrivenDelay_2();
      }
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_LoadLevel_uScriptAct_LoadLevel_0.Loaded -= uScriptAct_LoadLevel_Loaded_0;
   }
   
   void Instance_OnButtonClick_4(object o, uScript_Button.ClickEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnButtonClick_4( );
   }
   
   void uScriptAct_LoadLevel_Loaded_0(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Loaded_0( );
   }
   
   void Relay_Loaded_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("bd11cc7e-00a9-4199-b416-532dcea20eab", "Load_Level", Relay_Loaded_0)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript LoadScene1.uscript at Load Level.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("bd11cc7e-00a9-4199-b416-532dcea20eab", "Load_Level", Relay_In_0)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadLevel_uScriptAct_LoadLevel_0.In(logic_uScriptAct_LoadLevel_name_0, logic_uScriptAct_LoadLevel_destroyOtherObjects_0, logic_uScriptAct_LoadLevel_blockUntilLoaded_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript LoadScene1.uscript at Load Level.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ed8c4725-a86f-446c-ac25-6b180b51a2a1", "UnityEngine_Animator", Relay_Play_1)) return; 
         {
            {
               method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_stateName_1 = local_StartAnim_System_String;
               
            }
         }
         {
            UnityEngine.Animator component;
            component = local_3_UnityEngine_GameObject.GetComponent<UnityEngine.Animator>();
            if ( null != component )
            {
               component.Play(method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_stateName_1);
            }
         }
         Relay_In_2();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript LoadScene1.uscript at UnityEngine.Animator.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1e117c09-d801-449a-ae3f-ac056153a8a7", "Delay", Relay_In_2)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_2.In(logic_uScriptAct_Delay_Duration_2, logic_uScriptAct_Delay_SingleFrame_2);
         logic_uScriptAct_Delay_DrivenDelay_2 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_2.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_0();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript LoadScene1.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1e117c09-d801-449a-ae3f-ac056153a8a7", "Delay", Relay_Stop_2)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_2.Stop(logic_uScriptAct_Delay_Duration_2, logic_uScriptAct_Delay_SingleFrame_2);
         logic_uScriptAct_Delay_DrivenDelay_2 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_2.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_0();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript LoadScene1.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_2( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_Delay_DrivenDelay_2 = logic_uScriptAct_Delay_uScriptAct_Delay_2.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_2 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_2.AfterDelay == true )
            {
               Relay_In_0();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript LoadScene1.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_OnButtonClick_4()
   {
      if (true == CheckDebugBreak("9877c9e1-7d39-496e-9dc1-7902fda30a67", "UI_Button_Events", Relay_OnButtonClick_4)) return; 
      Relay_Play_1();
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "LoadScene1.uscript:3", local_3_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "793987c4-0c2a-454a-9f7f-5992f273a3fa", local_3_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "LoadScene1.uscript:5", local_5_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0abba965-21bb-48b6-a3d7-44f95e4e05a1", local_5_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "LoadScene1.uscript:StartAnim", local_StartAnim_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "33533011-b5ec-42ae-8579-b408130e5f7d", local_StartAnim_System_String);
   }
   bool CheckDebugBreak(string guid, string name, ContinueExecution method)
   {
      if (true == m_Breakpoint) return true;
      
      if (true == uScript_MasterComponent.FindBreakpoint(guid))
      {
         if (uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint == guid)
         {
            uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint = "";
         }
         else
         {
            uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint = guid;
            UpdateEditorValues( );
            UnityEngine.Debug.Log("uScript BREAK Node:" + name + " ((Time: " + Time.time + "");
            UnityEngine.Debug.Break();
            #if (!UNITY_FLASH)
            m_ContinueExecution = new ContinueExecution(method);
            #endif
            m_Breakpoint = true;
            return true;
         }
      }
      return false;
   }
}
