import { Link } from 'react-router-dom';
import './Sidebar.css';

function Sidebar() {
    return (
        <div className="w3-sidebar w3-light-grey w3-bar-block">
            <a href="/clients" className={"w3-bar-item w3-button"}>Clients</a>
            <a href="/trainers" className="w3-bar-item w3-button">Trainers</a>
            <a href="/calendar" className="w3-bar-item w3-button">Calendar</a>
            <a href="/myreviews" className="w3-bar-item w3-button">My reviews</a>
            
        </div>
    )
}

export default Sidebar;