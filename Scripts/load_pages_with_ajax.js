$(document).ready(function(){
    //ajax
    var default_content="";
    $('.nav li').click(function (e) {
            $(this).parent().find("li").removeClass("active");  
            $(this).addClass("active");
            console.log("lqlqlq");
            loadPage($(this).children("a").attr("href"));
    });
    default_content = $('#main_content').html();
});

function loadPage(url) {
    console.log(url);
    url=url.replace("#","");
    $.ajax({
        type: "POST",
        url: "/Home/" + url,
        data: "page="+url,
        dataType: "html",
        success: function(msg){
            if(parseInt(msg)!=0){
                $("#main_content").html(msg);
            }
        }
    });
}
   
	

   



