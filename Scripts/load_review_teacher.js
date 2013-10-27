$(".go-button").on("click", function(){   
    var teacherID=$(this).data("teacher-id"); 
    $.ajax({
        type: "POST",
        url: "/Teacher/_TeacherRating",
        context:this,
        data: {
            teacherId: teacherID
        },
        success: function(msg){
            $("#slider-header").html(msg);
        }
    });

    $.ajax({
        type: "POST",
        url: "/teacher/_TeacherBody",
        context:this,
        data: {
            teacherId: teacherID
        },
        success: function(msg){
            $("#main_content").html(msg);
        }
    });
             
});