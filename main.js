
//Here i have function that prints how many crows left on the wall

var message =  "1 fell down and became a wight.";
//when one crow left on the wall
var zero = "1 crow on the wall. 1 single crow.<br>It fell down and became a wight.<br>There's no one left to defend Westeros now.";
//when no crow is left on the wall

for(var i = 99; i>0; i--){
var word = i + " crows on the wall. "+ i +" crows."; //99 crows on the wall. 99 crows.

  if(i==1){
      printMessage(zero);     //print value in var zero
  }else{
      printMessage(word);     //print value in var word
      printMessage(message); //print value in var message
    if((i-1)==1){
      printMessage((i-1) +" crow on the wall");
    }else{
      printMessage((i-1) +" crows on the wall");
    }
  }
  printMessage("<br>");
}

function printMessage(printThis){
  document.open();
  document.write("<div class=\"printcrow\">"+printThis+"</div>");
  document.close();
}
