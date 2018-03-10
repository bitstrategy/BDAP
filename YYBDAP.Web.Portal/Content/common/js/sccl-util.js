/*设置cookie*/
function setCookie(name, value, days){
	if(days == null || days == ''){
		days = 300;
	}
	var exp  = new Date();
	exp.setTime(exp.getTime() + days*24*60*60*1000);
	document.cookie = name + "="+ escape (value) + "; path=/;expires=" + exp.toGMTString();
}

/*获取cookie*/
function getCookie(name) {
	//var arr,reg=new RegExp("(^| )"+name+"=([^;]*)(;|$)");
	//if (arr = document.cookie.match(reg)) {
	//    alert("获取cook成功：" + unescape(arr[2]));
	//    return unescape(arr[2]); 
	//}
	//else {
	//    alert("获取cook失败");
	//    return null;
    //}

    var cklist = document.cookie ? document.cookie.split('; ') : [];
    for (var i = 0; i < cklist.length; i++) {
        var keylist = cklist[i].split("=");
        if (keylist[0] == name) {
            //alert("获取cook成功：" + keylist[1]);
            return keylist[1];
        }
    }
    return null;
}

/*ajax请求*/
function ajax(url, param, datat, callback) {  
	$.ajax({  
		type: "post",  
		url: url,  
		data: param,  
		dataType: datat,  
		success: function(data){
			callback;
		},  
		error: function () {  
			alert("失败.."); 
		}
	});  
}

function Logout(url) {
    if (window.confirm("您确定要退出吗？(Y/N)")) {
        window.location.href = url;
    }
    return;
}