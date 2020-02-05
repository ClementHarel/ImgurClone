package md543ae6766cf480101098bebba88e8df86;


public class APICall
	extends md543ae6766cf480101098bebba88e8df86.MainActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DEV_epicture_2019.APICall, DEV_epicture_2019", APICall.class, __md_methods);
	}


	public APICall ()
	{
		super ();
		if (getClass () == APICall.class)
			mono.android.TypeManager.Activate ("DEV_epicture_2019.APICall, DEV_epicture_2019", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
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
