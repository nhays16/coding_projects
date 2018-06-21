$(document).ready(function(){
    $('form').submit(function(){
        var fname = $('#first-name').val();
        var lname = $('#last-name').val();
        var email = $('#email').val();
        var phone = $('#phone').val();
        var info = "<tr><td>" + fname + "</td><td>" + lname + "</td><td>" + email + "</td><td>" + phone + "</td></tr>";
        $('table tbody').append(info);   
            return false;
    });
})