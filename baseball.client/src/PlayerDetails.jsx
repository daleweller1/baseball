import React from "react";

const PlayerDetails = ({ player, onEdit }) => {
    if (!player) return <p>Select a player to see details</p>;

    return (
        <div>
            <h2>{player.name} ({player.position})</h2>
            <p>Games: {player.games}</p>
            <p>Hits: {player.hits}</p>
            <p>Home Runs: {player.homeRuns}</p>
            <p>Batting Average: {player.battingAverage.toFixed(3)}</p>
            <p>On-Base Percentage: {player.onBasePercentage.toFixed(3)}</p>
            <p>Slugging Percentage: {player.sluggingPercentage.toFixed(3)}</p>
            <p>OPS: {player.ops.toFixed(3)}</p>
            <button onClick={() => onEdit(player)}>Edit</button>
        </div>
    );
};

export default PlayerDetails;
