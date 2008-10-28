try {
	window.alert = window.jqalert;
} catch (err) {
	window.alert('Your browser does not support overloading window.alert. ' + err);
}

