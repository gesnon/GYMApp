import './NavigationBar.css';
import { BrowserRouter, Route, Routes, useParams } from 'react-router-dom';
import ClientInfo from '../ClientInfo/ClientInfo';
function NavigationBar() {
    const { id } = useParams();

    return (
        <ul className="navigationBar">
            <a className={"button"} href={`/clients/About/${id}`}> About </a>
            <a className={"button"} href={`/clients/Measurement/${id}`}>Measurement </a>
            <a className={"button"} href="3">Routine </a>
        </ul>
    )
}

export default NavigationBar;