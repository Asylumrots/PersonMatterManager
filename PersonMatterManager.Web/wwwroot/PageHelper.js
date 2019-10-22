
//初始化控制器名称，方法名称，ulid
var controllerName, functionName, gId, uId, showDataFunc,totalIndex;
//初始化方法
function loadPageAndNva(controllerNames, functionNames, gIds, uIds, showDataFuncs) {
    controllerName = controllerNames;
    functionName = functionNames;
    gId = gIds;
    uId = uIds;
    showDataFunc = showDataFuncs;
}

//获取分页信息
function GetPageInfo(PageIndex, PageSize) {
    //返回写出来，不写在ajax回调函数中，否则undefind
    var datas;
    $.ajax({
        type: "post",
        async: false,
        url: "/" + controllerName + "/" + functionName,
        data: { PageIndex: PageIndex, PageSize: PageSize },
        success: function (data) {
            //console.log(data);
            $("#" + gId + "").empty();
            totalIndex = Math.ceil(data.num / PageSize);
            //加载页面栏
            ShowNva(PageSize, totalIndex, PageIndex);
            //加载数据
            datas = data.list;
            console.log(datas);
        }
    });
    return datas;
}

//显示数据
//function ShowData(showDataFunc) {
    //var html;
    //if (data.length === 0) {
    //    html = '<tr style="text-align:center;">暂无数据</tr>';
    //    $("#" + gId + "").append(html);
    //}
    //else {
    //    html = '<tr><td><div style=""><input type="checkbox" style="height:15px;width:15px;position:relative;left:7px;bottom:2px"></div></td>';
    //    for (var i = 0; i < data.length; i++) {
    //        var item = data[i];
    //        for (var prop in item) {
    //            console.log(prop + "-----" + item[prop])
    //            html += '<td style="text-align:center">' + item[prop]+'</td>';
    //        }
    //        html += '</tr>';
    //        //console.log(html);
    //        $("#" + gId + "").append(html);
    //    }
    //}
//}

//显示页码栏
function ShowNva(PageSize, TotalIndex, PageIndex) {
    var li = "";
    //在选页数超过3时
    if (PageIndex > 3) {
        var num1, num2, num3, num4, num5;
        num1 = PageIndex - 2;
        num2 = PageIndex - 1;
        num3 = PageIndex;
        num4 = PageIndex + 1;
        num5 = PageIndex + 2;
        if (PageIndex === TotalIndex) {
            //console.log("最后一页")
            num1 -= 2; num2 -= 2; num3 -= 2; num4 -= 2; num5 -= 2;
        }
        else if (PageIndex === (TotalIndex - 1)) {
            //console.log("最后二页")
            num1 -= 1; num2 -= 1; num3 -= 1; num4 -= 1; num5 -= 1;
        }

        if (num1 == 0) {
            li = li + '<li><a onclick="GetPageInfo(' + num2 + ',' + PageSize + ')">' + num2 + '</a></li>';
            li = li + '<li><a onclick="GetPageInfo(' + num3 + ',' + PageSize + ')">' + num3 + '</a></li>';
            li = li + '<li><a onclick="GetPageInfo(' + num4 + ',' + PageSize + ')">' + num4 + '</a></li>';
            li = li + '<li><a onclick="GetPageInfo(' + num5 + ',' + PageSize + ')">' + num5 + '</a></li>';
        }
        else {
            li = li + '<li><a onclick="GetPageInfo(' + num1 + ',' + PageSize + ')">' + num1 + '</a></li>';
            li = li + '<li><a onclick="GetPageInfo(' + num2 + ',' + PageSize + ')">' + num2 + '</a></li>';
            li = li + '<li><a onclick="GetPageInfo(' + num3 + ',' + PageSize + ')">' + num3 + '</a></li>';
            li = li + '<li><a onclick="GetPageInfo(' + num4 + ',' + PageSize + ')">' + num4 + '</a></li>';
            li = li + '<li><a onclick="GetPageInfo(' + num5 + ',' + PageSize + ')">' + num5 + '</a></li>';
        }
        //console.log(num3)
        //console.log(li)
    }
    else {
        for (var i = 1; TotalIndex > 0; TotalIndex--) {
            li = li + '<li><a onclick="' + showDataFunc + '(' + i + ',' + PageSize + ')">' + i + '</a></li>';
            i++;
            //第一显示了5行就跳出循环
            if (i === 6) {
                break;
            }
        }
        //console.log(li)
    }
    $("#"+uId+"").empty();
    //上一页下一页
    var prenum = PageIndex - 1 <= 0 ? 1 : PageIndex - 1;
    var nextnum = PageIndex + 1 > TotalIndex ? TotalIndex : PageIndex + 1;
    var html = '<li><a onclick="' + showDataFunc + '(' + prenum + ',' + PageSize + ')">上一页</a></li>' + li +
        //'<li class="active"><a href="#">1</a></li>' +
        '<li><a onclick="' + showDataFunc + '(' + nextnum + ',' + PageSize + ')">下一页</a></li>';
    $("#" + uId + "").append(html);
    //去除所有active激发显示，并筛选当前页数的active
    for (var i = 0; i < $("#" + uId + "").children().length; i++) {
        $("#" + uId + "").children().eq(i).removeClass("active");
    }
    $("#pages li:contains(" + PageIndex + ")").addClass("active");
}

//数据库日期转换
function data_string(str) {
    var d = eval('new ' + str.substr(1, str.length - 2));
    var ar_date = [d.getFullYear(), d.getMonth() + 1, d.getDate(), d.getHours(), d.getMinutes(), d.getSeconds()];
    for (var i = 0; i < ar_date.length; i++) ar_date[i] = dFormat(ar_date[i]);
    return ar_date.slice(0, 3).join('-') + ' ' + ar_date.slice(3).join(':');
    function dFormat(i) { return i < 10 ? "0" + i.toString() : i; }
}