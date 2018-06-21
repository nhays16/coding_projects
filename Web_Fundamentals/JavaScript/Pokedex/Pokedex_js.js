$(document).ready(function(){
    for (var i = 1; i < 151; i++){
        $('#images').append(`<img class="${i}" src="https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/${i}.png">`)
    };
   
    $(document).on('click', 'img' , function(){
        var base_url = "https://pokeapi.co/api/v2/pokemon/";
        var currClass = $(this).attr('class');
        $.get(base_url + currClass + '/', function(response){
            //console.log(response);

            var html_str = "";
                html_str += "<div class='infocard'>";
                html_str += "<h1>" + response.name + "</h1>";
                html_str += '<div><img src="https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/'+currClass+'.png"></div>'

                html_str += "<h3>Types</h3>";
                html_str += "<ul>";
                for(var t = 0; t < response.types.length; t++){
                    html_str += "<li>" + response.types[t].type.name + "</li>";
                };
                html_str += "</ul>";
                html_str += "<h2>Height</h2>";
                html_str += "<p>" + response.height + "</p>";
                html_str += "<h2>Weight</h2>";
                html_str += "<p>" + response.weight + "</p>";
                html_str += "</div>";
                console.log(html_str);
                $('#pokedex').html(html_str);       
            }, "json"); 
        
        
    });

})