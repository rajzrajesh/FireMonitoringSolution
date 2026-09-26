import React, { useEffect, useState } from "react";
import * as signalR from "@microsoft/signalr";
import connection from "../services/signalRService";
import NotificationList from "../components/notifications/NotificationList";

function Notifications() {
    const [notifications, setNotifications] = useState([]);

    useEffect(() => {

        connection.off("ReceiveNotification");

        connection.on(
            "ReceiveNotification",
            (notification) => {

                console.log(
                    "Received Notification",
                    notification);

                setNotifications(prev => [
                    notification,
                    ...prev
                ]);
            }
        );

        const startSignalR = async () => {
            try {

                if (
                    connection.state ===
                    signalR.HubConnectionState.Disconnected
                ) {
                    await connection.start();

                    console.log(
                        "SignalR Connected");
                }
            }
            catch (error) {
                console.error(
                    "SignalR Error",
                    error);
            }
        };

        startSignalR();

        return () => {
            connection.off(
                "ReceiveNotification");
        };

    }, []);

    return (
        <div>
            <NotificationList
                notifications={notifications}
            />
        </div>
    );
}

export default Notifications;