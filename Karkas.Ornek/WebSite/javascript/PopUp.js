function OpenBrWindow(url,baslik,height,width,scroll) { 
        winl = (screen.width-width)/2;
        wint = (screen.height-height)/2;
        
        windowArgument = "width="+width+",height="+height; //+",top="+wint+",left="+winl;
        

    window.open(url,baslik,windowArgument);
}

/*/
/ /  Author: Jeremy Falcon
/ /    Date: November 08, 2001
/ / Version: 1.4
/*/

/*/ THIS FILE CONTAINS FUNCTIONS THAT WILL WRAP THE POP-UP PROCESS /*/

// this variable will hold the window obect
// we only allow one pop-up at a time
var popup = null;

/*/
/ / PURPOSE:
/ /		To create and center a pop-up window.
/ /
/ / COMMENTS:
/ /		It will replace to old pop-up if called
/ / 	without calling DestroyWnd() first..
/*/

function CreateWnd (file, width, height, resize)
{
	var doCenter = false;

	if((popup == null) || popup.closed)
	{
		attribs = "";

		/*/ there's no popup displayed /*/

		// assemble some params
		if(resize) size = "yes"; else size = "no";

		/*/
		/ / We want to center the pop-up; however, to do this we need to know the
		/ / screen size.  The screen object is only available in JavaScript 1.2 and
		/ / later (w/o Java and/or CGI helping), so we must check for the existance
		/ / of it in the window object to determine if we can get the screen size.
		/ /
		/ / It is safe to assume the window object exists because it was implemented
		/ / in the very first version of JavaScript (that's 1.0).
		/*/
		for(var item in window)
			{ if(item == "screen") { doCenter = true; break; } }

		if(doCenter)
		{	/*/ center the window /*/

			// if the screen is smaller than the window, override the resize setting
			if(screen.width <= width || screen.height <= height) size = "yes";

			WndTop  = (screen.height - height) / 2;
			WndLeft = (screen.width  - width)  / 2;

			// collect the attributes
			attribs = "width=" + width + ",height=" + height + ",resizable=" + size + ",scrollbars=" + size + "," + 
			"status=no,toolbar=no,directories=no,menubar=no,location=no,top=" + WndTop + ",left=" + WndLeft;
		}
		else
		{
			/*/
			/ / There is still one last thing we can do for JavaScrpt 1.1
			/ / users in Netscape.  Using the AWT in Java we can pull the
			/ / information we need, provided it is enabled.
			/*/
			if(navigator.appName=="Netscape" && navigator.javaEnabled())
			{	/*/ center the window /*/

				var toolkit = java.awt.Toolkit.getDefaultToolkit();
				var screen_size = toolkit.getScreenSize();

				// if the screen is smaller than the window, override the resize setting
				if(screen_size.width <= width || screen_size.height <= height) size = "yes";

				WndTop  = (screen_size.height - height) / 2;
				WndLeft = (screen_size.width  - width)  / 2;

				// collect the attributes
				attribs = "width=" + width + ",height=" + height + ",resizable=" + size + ",scrollbars=" + size + "," + 
				"status=no,toolbar=no,directories=no,menubar=no,location=no,top=" + WndTop + ",left=" + WndLeft;
			}
			else
			{	/*/ use the default window position /*/

				// override the resize setting
				size = "yes";

				// collect the attributes
				attribs = "width=" + width + ",height=" + height + ",resizable=" + size + ",scrollbars=" + size + "," + 
				"status=no,toolbar=no,directories=no,menubar=no,location=no";
			}
		}

		// create the window
		popup = open(file, "", attribs);
	}
	else
	{
		// destory the current window
		DestroyWnd();
		// recurse, just once, to display the new window
		CreateWnd(file, width, height, resize);
	}
}

/*/
/ / PURPOSE:
/ /		To destroy the pop-up window.
/ /
/ / COMMENTS:
/ /		This is available if wish to destroy
/ / 	the pop-up window manually.
/*/

function DestroyWnd ()
{
	// close the current window
	if(popup != null)
	{
		popup.close();
		popup = null;
	}
}

