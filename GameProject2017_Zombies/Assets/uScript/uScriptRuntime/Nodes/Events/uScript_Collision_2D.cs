// uScript uScript_Collision2D.cs
// (C) 2013 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Events/Physics Events (2D)")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a 2D collision.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("On Collision (2D)", "Fires an event signal when Instance GameObject receives a 2D collision. The GameObjects involved must have a 2D rigidbody component on them to fire this event.")]
public class uScript_Collision_2D : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CollisionEventArgs args);

   public class CollisionEventArgs : System.EventArgs
   {
      private Collision2D m_Collision;

      [FriendlyName("Relative Velocity", "The relative linear velocity of the two colliding GameObjects.")]
      [SocketState(false, false)]
      public Vector2 RelativeVelocity { get { return m_Collision.relativeVelocity; } }

      [FriendlyName("Rigid Body", "The rigidbody component of the 'Triggered By' GameObject that caused this event to fire. This is null if the 'Triggered By' GameObject is a collider with no rigidbody attached.")]
      [SocketState(false, false)]
      public Rigidbody2D RigidBody { get { return m_Collision.rigidbody; } }

      [FriendlyName("Collider", "The collider component of the 'Triggered By' GameObject that casued this event to fire.")]
      [SocketState(false, false)]
      public Collider2D Collider2D { get { return m_Collision.collider; } }

      [FriendlyName("Transform", "The transform component of the 'Triggered By' GameObject that caused this event to fire.")]
      [SocketState(false, false)]
      public Transform Transform { get { return m_Collision.transform; } }

      [FriendlyName("Contact Points", "The contact points generated by the physics engine from the collision.")]
      [SocketState(false, false)]
      public ContactPoint2D[] Contacts { get { return m_Collision.contacts; } }

      [FriendlyName("Triggered By", "The GameObject that collided with this GameObject (the Instance) and caused this event to fire.")]
      public GameObject GameObject { get { return m_Collision.gameObject; } }

      public CollisionEventArgs(Collision2D collision)
      {
         m_Collision = collision;
      }
   }

   [FriendlyName("On Collision Enter")]
   public event uScriptEventHandler OnEnterCollision2D;

   [FriendlyName("On Collision Exit")]
   public event uScriptEventHandler OnExitCollision2D;

   [FriendlyName("On Collision Stay")]
   public event uScriptEventHandler WhileInsideCollision2D;
 
   void OnCollisionEnter2D(Collision2D collision)
   {
      if ( OnEnterCollision2D != null ) OnEnterCollision2D( this, new CollisionEventArgs(collision) ); 
   }

   void OnCollisionExit2D(Collision2D collision)
   {
      if ( OnExitCollision2D != null ) OnExitCollision2D( this, new CollisionEventArgs(collision) ); 
   }

   void OnCollisionStay2D(Collision2D collision)
   {
      if ( WhileInsideCollision2D != null ) WhileInsideCollision2D( this, new CollisionEventArgs(collision) ); 
   }
}

#endif
