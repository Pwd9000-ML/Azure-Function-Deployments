const url = 
  "https://conscount02.azurewebsites.net/api/ConsCount02/";    
const data = { URL: "Github" };

const response = await fetch(url, {
  method: "POST",
  body: JSON.stringify(data),
  headers: {
    "Content-Type": "application/json",
  },
});
const body = await response.json();
console.log("Success:", JSON.stringify(response));