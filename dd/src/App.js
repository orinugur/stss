import React from "react";
import Board from "./components/Board";
import styles from "./App.module.css";

function App() {
  return (
    <div className={styles.app}>
      <h1>React 테트리스</h1>
      <Board />
    </div>
  );
}

export default App;