package md5f6244ca79b7e5745ebf0dfe737b11976;


public class BottomSheetActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("CourierService_MobileApp.BottomSheetActivity, CourierService_MobileApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BottomSheetActivity.class, __md_methods);
	}


	public BottomSheetActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BottomSheetActivity.class)
			mono.android.TypeManager.Activate ("CourierService_MobileApp.BottomSheetActivity, CourierService_MobileApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
