$(document).ready(function(){
    $('img').click(function(){
        console.log('data-alt-src value is', $(this).attr('data-alt-src'));
    })

    $('img').click(function(){
       $(this).attr('src',$(this).attr('data-alt-src'));
    })
})