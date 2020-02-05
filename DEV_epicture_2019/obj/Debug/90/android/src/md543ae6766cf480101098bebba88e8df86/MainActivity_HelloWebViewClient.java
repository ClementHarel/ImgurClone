package md543ae6766cf480101098bebba88e8df86;


public class MainActivity_HelloWebViewClient
	extends android.webkit.WebViewClient
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_shouldOverrideUrlLoading:(Landroid/webkit/WebView;Landroid/webkit/WebResourceRequest;)Z:GetShouldOverrideUrlLoading_Landroid_webkit_WebView_Landroid_webkit_WebResourceRequest_Handler\n" +
			"";
		mono.android.Runtime.register ("DEV_epicture_2019.MainActivity+HelloWebViewClient, DEV_epicture_2019", MainActivity_HelloWebViewClient.class, __md_methods);
	}


	public MainActivity_HelloWebViewClient ()
	{
		super ();
		if (getClass () == MainActivity_HelloWebViewClient.class)
			mono.android.TypeManager.Activate ("DEV_epicture_2019.MainActivity+HelloWebViewClient, DEV_epicture_2019", "", this, new java.lang.Object[] {  });
	}


	public boolean shouldOverrideUrlLoading (android.webkit.WebView p0, android.webkit.WebResourceRequest p1)
	{
		return n_shouldOverrideUrlLoading (p0, p1);
	}

	private native boolean n_shouldOverrideUrlLoading (android.webkit.WebView p0, android.webkit.WebResourceRequest p1);

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
