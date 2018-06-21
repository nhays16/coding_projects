$(document).ready(function(){
    $('#addUser').click(function(){
        var fname = $('#first-name').val();
        var lname = $('#last-name').val();
        var info = fname + '' + lname;
        var desc = $('textarea').val();
        $('#info').append("<div id = 'cards'><p>" + info + "<p><p id = 'back'>" + desc + "</p></div>");

        $('#first-name').val("");
        $('#last-name').val("");
        $('textarea').val("");
            return false;
    });

    $(document).on('click', '#cards', function(){
        $(this).children().toggle();

    });
})