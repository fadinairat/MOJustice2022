
//Autocomplete AJAX
// AJAX call for autocomplete 
$(document).ready(function(){
    $("#get_link_btn").click(function(){
        if($("#search_link").val()!=""){            
            $("#"+$("#get_link_icon").data("text")).val($("#search_link").val());
            $("#search_link").val("");
            $("#search_text").val("");
            $('#linkmodal').modal('hide');
        }
        else{
            $("#suggesstion-box").html("<font color=red >You have to choose link!</font>");
        }
    }); 

    $('input[name="lang_rad"], input[name="link_type_rad"]').change(function(){
        $("#search_text").val("");
        $("#suggesstion-box").html("");
        $("#suggesstion-box").hide();
    });

    $("#page_parent_title").keyup(function(){
        if($("#page_parent_title").val()!=""){            
            //var lang = $('#page_language').val();  
            var lang = $("#lang").val();
            var type = "page";            
            //if(lang == "") lang = "0";
            var url ="~/Control/Pages/getParents?keyword="+$(this).val()+"&type=page";
                       
            $.ajax({        
                url: url,       
                dataType: "json",
                beforeSend: function(){
                    $("#page_parent_title").css("background","#FFF url(LoaderIcon.gif) no-repeat 165px");
                },
                success: function(data){
                    var items = data.items;                    
                    var html = "<div style='position:absolute;right:5px;top:5px;' ><i id='close_parents' style='cursor:pointer;' class='fa fa-times' aria-hidden='true'></i></div>";
                    html += "<ul id='items-list' >";

                    for(var i=0;i<items.length;i++){
                        if(type == "page"){
                            var p_title = items[i].p_title.replace("'","");                        
                            p_title = p_title.replace('"',''); 
                            p_title = p_title.replace('(',''); 
                            p_title = p_title.replace(')',''); 
                            p_title=p_title.replace(/(?:(?:\r\n|\r|\n)\s*){2}/gm, "");
                            html +="<li onClick='selectParent(\""+items[i].p_id+"\",\""+p_title+"\","+items[i].p_lang+");' >"+items[i].p_title+"</li>";
                        }
                        else if(type == "category"){
                            var c_name = items[i].cat_name.replace("'","");  
                            
                            html +="<li onClick='selectParent(\""+items[i].c_id+"\",\""+c_name+"\","+items[i].c_lang+");' >"+items[i].cat_name+"</li>";
                        }
                        else if(type == "file"){
                            var f_title = items[i].file_title.replace("'","");                        
                            html +="<li onClick='selectParent(\""+items[i].f_id+"\",\""+f_title+"\","+items[i].f_lang+");' >"+items[i].file_title+"</li>";
                        }                        
                    }

                    html +="</ul>";
                    $("#parents_box").show();
                    $("#parents_box").html(html);
                    $("#page_parent_title").css("background","#FFF");
                },
                error: function (jqXhr, json, errorThrown) {
                    try{
                        var errors = jqXhr.responseJSON.errors;
                        $("#parents_box").html("<font color='red' >"+errors[0]+"</font>"); 
                        $("#parents_box").show();              
                        console.log(errors);
                    }
                    catch(eee){
                        console.log(eee.message);
                    }
                }
            });
            
        }
        else{            
            $("#page_parent").val("0");
            $("#page_parent_title").val("");
        }      
    });

    $("#search_text").keyup(function(){
        if($("#search_text").val()!=""){
            var type = $('input[name="link_type_rad"]:checked').val();  
            var lang = $('input[name="lang_rad"]:checked').val();  
            var url ="../Pages/getLinks?keyword="+$(this).val()+"&type="+type+"&lang="+lang;
            
            $.ajax({        
                url: url,       
                dataType: "json",
                beforeSend: function(){
                    $("#search_text").css("background","#FFF url(LoaderIcon.gif) no-repeat 165px");
                },
                success: function(data){
                    var items = data.links;                    
                    var html = "<ul id='items-list' >";

                    for(var i=0;i<items.length;i++){
                        if(type == "page"){
                            var p_title = items[i].title.replace("'","");                        
                            p_title = p_title.replace('"',''); 
                            p_title = p_title.replace('(',''); 
                            p_title = p_title.replace(')',''); 
							p_title = p_title.replace(/(?:(?:\r\n|\r|\n)\s*){2}/gm, "");
                            html +="<li onClick='selectLink(\""+items[i].pageId+"\",\""+p_title+"\","+items[i].langId+");' >"+items[i].title+"</li>";
                        }
                        else if(type == "category"){
                            var c_name = items[i].name.replace("'","");  
                            
                            html +="<li onClick='selectLink(\""+items[i].id+"\",\""+c_name+"\","+items[i].langId+");' >"+items[i].name+"</li>";
                        }
                        else if(type == "file"){
                            var f_title = items[i].name.replace("'","");                        
                            html +="<li onClick='selectLink(\""+items[i].id+"\",\""+f_title+"\","+items[i].langId+");' >"+items[i].name+"</li>";
                        }                        
                    }

                    html +="</ul>";
                    $("#suggesstion-box").show();
                    $("#suggesstion-box").html(html);
                    $("#search_text").css("background","#FFF");
                },
                error: function (jqXhr, json, errorThrown) {
                    try{
                        var errors = jqXhr.responseJSON.errors;
                        $("#suggesstion-box").html("<font color='red' >"+errors[0]+"</font>"); 
                        $("#suggesstion-box").show();              
                        console.log(errors);
                    }
                    catch(eee){
                        console.log(eee.message);
                    }
                }
            });
        }
        else{            
            $("#search_link").val("");
            $("#search_text").val("");
        }        
    });

    $(document).on("click","#close_parents",function(){       
        $("#parents_box").html("");
    });
});

function closeList(){
    setTimeout(function(){
        $("#parents_box").html("");
    },1000)
    
}


//To select country name
function selectLink(val,text,lang) {
    $("#search_text").val(text);
	text=text.split(" ").join("-").toLowerCase();
    $("#suggesstion-box").hide();
    var type = $('input[name="link_type_rad"]:checked').val();    
    var type_txt = "Page";
    if(type == "page") type_txt = "Pages/Details";
    else if (type == "category") type_txt = "Categories/Details";
    else if (type == "file") type_txt = "Files/Details";

    var lang_pref = "";
    if(lang == 1) lang_pref = "ar/";
    else if(lang == 2) lang_pref="ar/";
    else if(lang == 3) lang_pref="en/";
    else lang_pref = "";
   
    //$("#search_link").val(lang_pref+""+type_txt+"/"+val+"/"+encodeURIComponent(text));
    $("#search_link").val(lang_pref+""+type_txt+"/"+val+"/"+text);
    //$("#search_link").val(lang_pref+text);
}


function selectParent(val,text,lang) {
    $("#page_parent_title").val(text);
    $("#page_parent").val(val);
    text=text.split(" ").join("-").toLowerCase();
    $("#parents_box").hide();
    $("#rem_parent").removeClass("rem_hidden");
    /*var type = "page";
    var type_txt = "Page";
    if(type == "page") type_txt = "Article";
    else if(type == "category") type_txt = "Category";
    else if(type == "file") type_txt = "File";

    var lang_pref = "";
    if(lang == 1) lang_pref = "ar/";
    else lang_pref = "en/";
    //$("#search_link").val(lang_pref+""+type_txt+"/"+val+"/"+encodeURIComponent(text));
    $("#search_link").val(lang_pref+""+type_txt+"/"+val+"/"+text);
    */
}
//menu_link
