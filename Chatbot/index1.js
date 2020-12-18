let databasecontents = ["orderid", "name", "mobile", "email", "item", "order_time"];
let overallcount=0;
let pre_response;
let search_id;
let flag;
let statuscheckingprocess;
document.addEventListener("DOMContentLoaded", () => {
    const inputField = document.getElementById("input");
    inputField.addEventListener("keydown", (e) => {
      if (e.code === "Enter") {
        let input = inputField.value;
        inputField.value = "";
        output(input);
        }
        
    });
  });
  
  function output(input) {
    let product;
    let found=false;
    
    let text = input.toLowerCase();
    newarray=[
            ["hi","Hello!.....Welcome to YOYO PIZZZA\n How can i help you?\n order pizza or check status"],
            ["hru","fine"],
            ["order pizza","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?"],
            ["pizza","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?"],
            ["i want menu","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?"],
            ["i want pizza","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?"],
            ["menu please","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?"],
            ["pizza please","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?"],
            ["show me the menu","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?"],
            ["give me pizza","We serve \ncheese pizza,\nveg pizza,\nitalian pizza,\nchicken pizza,\nmushroom pizza,\npaneer pizza...\n what is your choice?"],
            ["cheese pizza","Great choice....Your Cheese pizza is getting ready \nEnter ok to confirm you order "],
            ["veg pizza","Great choice....Your Veg pizza is getting ready \nEnter ok to confirm you order "],
            ["italian pizza", "Great choice....Your Italian pizza is getting ready \nEnter ok to confirm you order "],
            ["chicken pizza", "Great choice....Your Chicken pizza is getting ready \nEnter ok to confirm you order "],
            ["mushroom pizza","Great choice....Your Mushroom pizza is getting ready \nEnter ok to confirm you order "],
            ["paneer pizza","Great choice....Your Paneer pizza is getting ready \nEnter ok to confirm you order "],  
            ["status","Enter 'yes' to know status"],
            ["check status","Enter 'yes' to know status"],
            ["i want to know the status","Enter 'yes' to know status"]      
        ];
    for(let i=0;i<newarray.length;i++)
    {
        for(let j=0;j<newarray.length;j++)
        {
            if(text==newarray[i][j])
            {
              product=newarray[i][j+1];
              if(text=="cheese pizza" || text=="veg pizza" || text=="italian pizza" || text=="chicken pizza" || text=="mushroom pizza" || text=="paneer pizza")
              {
                  databasecontents[4]=text;
              }
              found=true;
            }
            
        }
    }
    

    if(text=="ok" && found==false )
    {
        product="Enter your name";
    }
    else if(text=="yes"&& found==false)
    {
      flag=1;
        product = "Enter your order id";
        //Button1.Visible = true;
      //search and tell the status by sub from the curret time

    }
    else
    {
        if(overallcount==0 && found==false)
        {
            databasecontents[1]=text;
            product="Enter your mobile no";
            overallcount++;
        }
        else if(overallcount==1 && found==false)
        {
            databasecontents[2]=text;
            product="Enter your emailid";
            overallcount++;
        }
        else if(overallcount==2 && found==false)
        {
            databasecontents[3]=text;
            orderid=Math.floor((Math.random() * 999) + 100);
            databasecontents[0]=orderid;
            let d = new Date().toLocaleTimeString();
            databasecontents[5]=d;
            product="Your orderID is "+orderid+"\nThank you for shopping...";
          
            //insert databasecontents variable into the database
        }
      
    }
    if(statuscheckingprocess)
    {
      //search from databse 
     //calculate current_time - order_time
     //display the status
     /*
    let d5 = new Date().toLocaleTimeString();
    let time1 = d5.split(':');
    let time2 = current_status1.split(':');
    let minutes = Math.abs(Number(time1[1]) - Number(time2[1]));
    let hours = Math.floor(parseInt(minutes / 60));
    hours = Math.abs(Number(time1[0]) - Number(time2[0]) - hours);
    minutes = minutes % 60;
    if (hours.toString().length == 1) {
        hours = '0' + hours;
    }
    if (minutes.toString().length == 1) {
        minutes = '0' + minutes;
    }
    if (hours <= "00" && minutes <= "15") {
        
        product="Your order is placed just now and it will be deleived soon";

    }
    else if (hours <= "00" && minutes >= "15" && minutes <= "30") {   
        product="Your order will reach you very soon";

    }
    else if (hours <= "00" && minutes >= "30" && minutes <= "45") {
        product="Your order is deleivered successfully..";

    }
     */
      product="your order is out for delievery";
    }

    if(flag==1)
    {
      search_id=text;
      
     statuscheckingprocess=true;
    
    }
    
    addChat(input, product);
  }
  
  
  function addChat(input, product) {
    pre_response=input;
    const messagesContainer = document.getElementById("messages");
  
    let userDiv = document.createElement("div");
    userDiv.id = "user";
    userDiv.className = "user response";
    userDiv.innerHTML = `<img src="user.png" class="avatar"><span>${input}</span>`;
    messagesContainer.appendChild(userDiv);
  
    let botDiv = document.createElement("div");
    let botImg = document.createElement("img");
    let botText = document.createElement("span");
    botDiv.id = "bot";
    botImg.src = "bot-mini.png";
    botImg.className = "avatar";
    botDiv.className = "bot response";
    botText.innerText = "Typing...";
    botDiv.appendChild(botText);
    botDiv.appendChild(botImg);
    messagesContainer.appendChild(botDiv);
    // Keep messages at most recent
    messagesContainer.scrollTop = messagesContainer.scrollHeight - messagesContainer.clientHeight;
   
    // Fake delay to seem "real"
    setTimeout(() => {
     botText.innerText = `${product}`;
// textToSpeech(product)
   }, 2000
  )
  
  }
 