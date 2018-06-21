 $(document).ready(function(){
    $('#add-class button').click(function(){
        $('#add-class-p').addClass('red');
    })
    $('#fadein').click(function(){
        $('#fadein-p').fadeIn('slow');
    })
    $('#fadeout').click(function(){
        $('#fadeout-p').fadeOut('slow');
    })
    $('#slideup').click(function(){
        $('#slide p').slideUp('slow');
    })
    $('#slidedown').click(function(){
        $('#slide p').slideDown('slow');
    })
    $('#slidetoggle').click(function(){
        $('#slide p').slideToggle('slow');
    })
    $('#hide').click(function(){
        $('#hide-show h1').hide()
    })
    $('#show').click(function(){
        $('#hide-show h2').show()
    })
    $('#toggle button').click(function(){
        $('#toggle p').toggle(
            function(){
                $(this).before("Hello");
            },
            function(){
                $(this).after("Hello");
            }
        );
    });
    $('#add-class h1').html("<span class='red'>Bonjour</span>");
    $('#append').append("And to you!!");
    $('#text').text("Who knew Text Functions could be so fun");

    $('#data').data("test", {first: "Happy", last: "Holidays"});
    $('#data span:first').text($('#data').data("test").first);
    $('#data span:last').text($('#data').data("test").last);

    var title = $('em').attr("title");
    $('h4').text(title);

    $('input').keyup(function(){
        var value = $(this).val();
        $('#value p').text(value);
    })
    .keyup();
    

})