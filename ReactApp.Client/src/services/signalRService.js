import * as signalR from "@microsoft/signalr";

const connection =
    new signalR.HubConnectionBuilder()
        .withUrl(
            "https://localhost:44397/notificationHub"
        )
        .withAutomaticReconnect()
        .build();

export default connection;