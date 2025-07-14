import React from "react";
import styles from "./Cell.module.css";

function Cell({ value }) {
  return (
    <div className={value ? styles[`color${value}`] : styles.cell}></div>
  );
}

export default Cell;