function conf(msg){
	var con = confirm(msg);
	if(con == true){
	    return true;
	}
	else{
		return false;
	}
}
function CreateXMLHttpRequest(){
    var xmlHttp
    if(window.ActiveXObject){
        xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");
    }
    else if(window.XMLHtpRequest){
        xmlHttp=new XMLHttpRequest();
    }
    return xmlHttp;
}

function trim(strTemp){
	var str=new String(strTemp);
	var substr=new String("");
	if(str.length==0) return "";
	try{
		while((str.charAt(0)==" ")||(str.charAt(0)=="　"))
		{
			str=str.substr(1);
		}
		while((str.charAt(str.length-1)==" ")||(str.charAt(str.length-1)=="　"))
		{
			str=str.substr(0,str.length-1);
		}
	}
	catch(err)
	{}
	return str;
}

function DataFormat(objDate){
    var strCeckDate = trim(objDate.value);
    if(lenb(strCeckDate)!=8 && lenb(strCeckDate)!=10){
	    alert("请输入'yyyymmdd'或者'yyyy/mm/dd'的日期格式。");
		return false;
	}
	if(strCeckDate.length == 8){
	    try{	
		    if(isNaN(strCeckDate.substr(0,4)) || isNaN(strCeckDate.substr(4,6)) ||  isNaN(strCeckDate.substr(6,8))){
			    alert("请输入正确的日期格式。");
			    return false;
		    }
		}catch(err){
		    alert("请输入正确的日期格式。");
			return false;
		}
		strYear = strCeckDate.slice(0,4);
		strMonth = strCeckDate.slice(4,6);
		strDate = strCeckDate.slice(6,8);
		strCeckDate = strYear + '/' + strMonth + '/' + strDate;
		objDate.value = strCeckDate;
	}
	if(strCeckDate.replace("/","").replace("/","").length != 8 ){
	    alert("请输入正确的日期格式。");
		return false;
	}
	strCeckDate = objDate.value.split("/");
	bolRet = false;
	if(objDate.value == ""){
		bolRet = true;
	}
	else{		
		if(strCeckDate.length!=3){
			alert("请输入'yyyymmdd'或者'yyyy/mm/dd'的日期格式。");
			return false;
		}
		else{						
			if(isNaN(strCeckDate[0]) || isNaN(strCeckDate[1]) ||  isNaN(strCeckDate[2])){
				alert("请输入正确的日期格式。");
				return false;
			}						
			if(strCeckDate[0].length != 4){
				alert("年为4位。");
				return false;
			}
			else{				
				if((strCeckDate[1].length < 1) || (strCeckDate[1].length > 2)){
					alert("月份为2位。");
					return false;
				}
				else{					
					if((strCeckDate[2].length < 1) || (strCeckDate[2].length > 2)){
						alert("日期为2位。");
						return false;
					}
					else{						
						objNewDate = new Date(strCeckDate[0], parseInt(strCeckDate[1],10)-1, strCeckDate[2]);
						if((objNewDate.getDate() != strCeckDate[2]) || (strCeckDate[1] != objNewDate.getMonth()+1)){						
							alert("请输入正确的日期格式。");
							return false;
						}
						if(1900>parseInt(strCeckDate[0],10)){
							alert("输入内容无效。");
							return false;
						}						
						bolRet = true;
					}
				}
			}
		}
	}
	return bolRet;
}

function lenb(strTemp){
	var intLength=0;
	var str=new String(strTemp);
	for(var i=0;i<str.length;i++){
		if(str.charCodeAt(i)>255){
			if(charIsKn(str.charAt(i))){
				intLength++;
			}
			else{
				intLength+=2;
			}
		}
		else{
			intLength++;
		}
	}
	return intLength;
}

function charIsKn(strTemp){
	var str=new String(strTemp);
	for(var i=0;i<str.length;i++)
		if(str.charCodeAt(i)>65439 || str.charCodeAt(i)<65382)
			return false
	return true
}