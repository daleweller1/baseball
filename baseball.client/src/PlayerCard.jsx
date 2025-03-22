import React from "react";

const PlayerCard = ({ player, onEdit, onBio }) => {
    return (
        <div className="player-card" onClick={() => onBio(player)}>
            <h3>{player["Player name"]} ({player["position"]})</h3>
            <p><strong>Games:</strong> {player["Games"]}</p>
            <p><strong>At-Bats:</strong> {player["At-bat"]}</p>
            <p><strong>Runs:</strong> {player["Runs"]}</p>
            <p><strong>Hits:</strong> {player["Hits"]}</p>
            <p><strong>Doubles:</strong> {player["Double (2B)"]}</p>
            <p><strong>Triples:</strong> {player["third baseman"]}</p>
            <p><strong>Home Runs:</strong> {player["home run"]}</p>
            <p><strong>RBIs:</strong> {player["run batted in"]}</p>
            <p><strong>Walks:</strong> {player["a walk"]}</p>
            <p><strong>Strikeouts:</strong> {player["Strikeouts"]}</p>
            <p><strong>Stolen Bases:</strong> {player["stolen base"]}</p>
            <p><strong>Caught Stealing:</strong> {player["Caught stealing"]}</p>
            <p><strong>AVG:</strong> {player["AVG"]}</p>
            <p><strong>On-Base %:</strong> {player["On-base Percentage"]}</p>
            <p><strong>Slugging %:</strong> {player["Slugging Percentage"]}</p>
            <p><strong>OPS:</strong> {player["On-base Plus Slugging"]}</p>

            <button
                onClick={(e) => {
                    e.stopPropagation();
                    onEdit(player);
                }}
            >
                Edit
            </button>
        </div>
    );
};

export default PlayerCard;
