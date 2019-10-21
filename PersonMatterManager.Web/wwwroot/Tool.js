//根据部门id转换部门名称
function DepartmentFactory(departmentid) {
    var DeName = "暂无";
    $.ajax({
        type: "post",
        url: "/Department/GetDepartmentInfo",
        async: false,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                if (departmentid === data[i].DepartmentID) {
                    DeName = data[i].DepartmentName;
                }
            }
        }
    });
    return DeName;
};

//根据用户id转换用户名称
function UserNameFactory(userID) {
    var Name = "暂无";
    $.ajax({
        type: "post",
        url: "/Person/GetPerson",
        async: false,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                if (userID === data[i].UserID) {
                    Name = data[i].UserName;
                }
            }
        }
    });
    return Name;
}

//日期转换
function data_string(str) {
    if (str === null) {
        return "null";
    }
    var d = eval('new ' + str.substr(1, str.length - 2));
    var ar_date = [d.getFullYear(), d.getMonth() + 1, d.getDate(), d.getHours(), d.getMinutes(), d.getSeconds()];
    for (var i = 0; i < ar_date.length; i++) ar_date[i] = dFormat(ar_date[i]);
    return ar_date.slice(0, 3).join('-') + ' ' + ar_date.slice(3).join(':');
    function dFormat(i) { return i < 10 ? "0" + i.toString() : i; }
}

//获取当前时间
function getNowDate() {
    var date = new Date();
    var seperator1 = "-";
    var seperator2 = ":";
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var strDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
    var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
        + " " + hours + seperator2 + minutes
        + seperator2 + date.getSeconds();
    return currentdate;
}

//获取当前时间 符合input datetime 格式的
function getNowFormatDate() {
    var date = new Date();
    var seperator1 = "-";
    var seperator2 = ":";
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var strDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
    var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
        + "T" + hours + seperator2 + minutes
        + seperator2 + date.getSeconds();
    return currentdate;
}