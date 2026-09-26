import React from "react";

const NotificationList = ({ notifications }) => {
    return (
        <div className="notification-container">
            <h2>Fire Alarm Notifications</h2>

            <table className="notification-table">
                <thead>
                    <tr>
                        <th>Alarm Id</th>
                        <th>Recipient</th>
                        <th>Channel</th>
                        <th>Message</th>
                        <th>Status</th>
                        <th>Sent Time</th>
                    </tr>
                </thead>

                <tbody>
                    {notifications.map((notification) => (
                        <tr key={notification.id}>
                            <td>{notification.alarmId}</td>
                            <td>{notification.recipient}</td>
                            <td>{notification.channel}</td>
                            <td>{notification.message}</td>
                            <td>
                                <span className="status-success">
                                    {notification.status}
                                </span>
                            </td>
                            <td>
                                {new Date(
                                    notification.sentTime
                                ).toLocaleString()}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default NotificationList;
