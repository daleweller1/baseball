import React, { useEffect, useState } from "react";
import axios from "axios";
import "./PlayerBio.css";

const PlayerBioModal = ({ player, onClose }) => {
    const [bio, setBio] = useState("Loading biography...");

    useEffect(() => {
        const fetchBiography = async () => {
            try {
                const response = await axios.get(`https://localhost:7094/api/playerbio/${player["Player name"]}`);
                setBio(response.data.biography);
            } catch (error) {
                console.error("Error fetching biography:", error);
                setBio("Failed to load biography.");
            }
        };

        fetchBiography();
    }, [player]);

    return (
        <div className="modal-overlay" onClick={onClose}>
            <div className="modal" onClick={(e) => e.stopPropagation()}>
                <h2>{player["Player name"]} - Biography</h2>
                <p>{bio}</p>
                <button className="close-btn" onClick={onClose}>Close</button>
            </div>
        </div>
    );
};

export default PlayerBioModal;
