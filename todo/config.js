var config = {}

config.host = process.env.HOST || "https://easyfinder.documents.azure.com:443/";
config.authKey = process.env.AUTH_KEY || "1uIzklHfZR7ngDrQmsDLxz6nMhenluStETIrDU3MIFw6JCJ9eui1MF1VgjpW4RaeiUHAIitlJrbebuxrakw3Bg==";
config.databaseId = "ToDoList";
config.collectionId = "Items";

module.exports = config;
