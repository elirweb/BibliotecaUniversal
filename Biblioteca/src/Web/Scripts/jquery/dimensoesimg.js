jQuery("#img_principal").change(function() { //campo de imagem
    var fr = new FileReader;
    fr.onload = function() {
        var img = new Image;
        img.onload = function() {
        	if (img.width < 297 &&  this.height < 50) {
        		jQuery('.msg').append("<h2>Sua imagem é menor que 1400px de largura por 800px de altura </ br> use outra imagem</h2>");
       		          //jQuery("#submit").attr("disabled", true); //Desabilita o botão sumbit
        	
        	} else {
        		     jQuery('.aviso').remove(); //remove a DIV aviso
        		           jQuery('.aviso').append("<h3> Sua imagem tem as dimensões corretas</h3>"); //add outra mensagem
        		                 //jQuery("#submit").removeAttr("disabled"); // Abilita o botão submit
        	}
        
           };
        
        img.src = fr.result;
    };
    
    fr.readAsDataURL(this.files[0]);
    
});