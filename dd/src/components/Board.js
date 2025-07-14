import React, { useState, useEffect, useRef } from "react";
import Cell from "./Cell";
import { getInitialBoard, getRandomTetromino, checkCollision, mergeTetromino, clearLines, nextPosition } from "../utils/tetris";
import styles from "./Board.module.css";

const ROWS = 20;
const COLS = 10;
const INTERVAL = 500;

function Board() {
  const [board, setBoard] = useState(getInitialBoard(ROWS, COLS));
  const [current, setCurrent] = useState(getRandomTetromino(COLS));
  const [next, setNext] = useState(getRandomTetromino(COLS));
  const [score, setScore] = useState(0);
  const [gameOver, setGameOver] = useState(false);
  const intervalRef = useRef();

  useEffect(() => {
    if (gameOver) return;
    intervalRef.current = setInterval(() => {
      move("down");
    }, INTERVAL);
    return () => clearInterval(intervalRef.current);
    // eslint-disable-next-line
  }, [current, gameOver]);

  const move = (dir) => {
    if (gameOver) return;
    const { tetromino, pos } = current;
    const newPos = nextPosition(pos, dir);
    if (!checkCollision(board, tetromino, newPos)) {
      setCurrent({ ...current, pos: newPos });
    } else if (dir === "down") {
      const merged = mergeTetromino(board, tetromino, pos);
      const { newBoard, cleared } = clearLines(merged);
      setBoard(newBoard);
      setScore((s) => s + cleared * 100);
      if (pos.y <= 0) {
        setGameOver(true);
        clearInterval(intervalRef.current);
      } else {
        setCurrent(next);
        setNext(getRandomTetromino(COLS));
      }
    }
  };

  const rotate = () => {
    if (gameOver) return;
    const { tetromino, pos } = current;
    const rotated = tetromino[0].map((_, i) => tetromino.map(row => row[i]).reverse());
    if (!checkCollision(board, rotated, pos)) {
      setCurrent({ ...current, tetromino: rotated });
    }
  };

  const handleKeyDown = (e) => {
    if (gameOver) return;
    if (e.key === "ArrowLeft") move("left");
    else if (e.key === "ArrowRight") move("right");
    else if (e.key === "ArrowDown") move("down");
    else if (e.key === "ArrowUp") rotate();
    else if (e.key === " ") {
      // Hard drop
      let { tetromino, pos } = current;
      let dropPos = { ...pos };
      while (!checkCollision(board, tetromino, { ...dropPos, y: dropPos.y + 1 })) {
        dropPos.y += 1;
      }
      setCurrent({ ...current, pos: dropPos });
      move("down");
    }
  };

  useEffect(() => {
    window.addEventListener("keydown", handleKeyDown);
    return () => window.removeEventListener("keydown", handleKeyDown);
    // eslint-disable-next-line
  }, [current, board, gameOver]);

  const restart = () => {
    setBoard(getInitialBoard(ROWS, COLS));
    setCurrent(getRandomTetromino(COLS));
    setNext(getRandomTetromino(COLS));
    setScore(0);
    setGameOver(false);
  };

  // 현재 블록을 보드에 임시로 합쳐서 렌더링
  const displayBoard = mergeTetromino(board, current.tetromino, current.pos, true);

  return (
    <div className={styles.boardWrap}>
      <div className={styles.info}>
        <div>점수: {score}</div>
        <div>다음 블록:</div>
        <div className={styles.next}>
          {next.tetromino.map((row, i) => (
            <div key={i} className={styles.nextRow}>
              {row.map((cell, j) => (
                <span key={j} className={cell ? styles[`color${next.color}`] : styles.empty}></span>
              ))}
            </div>
          ))}
        </div>
      </div>
      <div className={styles.board}>
        {displayBoard.map((row, i) => (
          <div key={i} className={styles.row}>
            {row.map((cell, j) => (
              <Cell key={j} value={cell} />
            ))}
          </div>
        ))}
        {gameOver && (
          <div className={styles.gameOver}>
            <div>게임 오버</div>
            <button onClick={restart}>다시 시작</button>
          </div>
        )}
      </div>
    </div>
  );
}

export default Board;