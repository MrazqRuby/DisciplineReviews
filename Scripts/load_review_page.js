$(".go-button").on("click", function(){   
    var courseID=$(this).data("course-id");  //data-course-id = ""
    $.ajax({
        type: "POST",
        url: "/Course/_CourseRating",
        context:this,
        data: {
            courseId: courseID
        },
        success: function(msg){
            $("#slider-header").html(msg);
        }
    });

    $.ajax({
        type: "POST",
        url: "/Course/_CourseBody",
        context:this,
        data: {
            courseId: courseID
        },
        success: function(msg){
            $("#main_content").html(msg);
        }
    });
             
});