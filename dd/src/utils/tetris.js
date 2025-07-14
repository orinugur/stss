export function getInitialBoard(rows, cols) {
  return Array.from({ length: rows }, () => Array(cols).fill(0));
}

const TETROMINOS = [
  // I
  {
    shape: [
      [1, 1, 1, 1]
    ],
    color: 1
  },
  // O
  {
    shape: [
      [2, 2],
      [2, 2]
    ],
    color: 2
  },
  // T
  {
    shape: [
      [0, 3, 0],
      [3, 3, 3]
    ],
    color: 3
  },
  // S
  {
    shape: [
      [0, 4, 4],
      [4, 4, 0]
    ],
    color: 4
  },
  // Z
  {
    shape: [
      [5, 5, 0],
      [0, 5, 5]
    ],
    color: 5
  },
  // J
  {
    shape: [
      [6, 0, 0],
      [6, 6, 6]
    ],
    color: 6
  },
  // L
  {
    shape: [
      [0, 0, 7],
      [7, 7, 7]
    ],
    color: 7
  }
];

export function getRandomTetromino(cols) {
  const idx = Math.floor(Math.random() * TETROMINOS.length);
  const { shape, color } = TETROMINOS[idx];
  return {
    tetromino: shape,
    color,
    pos: { x: Math.floor((cols - shape[0].length) / 2), y: 0 }
  };
}

export function checkCollision(board, tetromino, pos) {
  for (let y = 0; y < tetromino.length; y++) {
    for (let x = 0; x < tetromino[0].length; x++) {
      if (tetromino[y][x]) {
        const newY = pos.y + y;
        const newX = pos.x + x;
        if (
          newY < 0 ||
          newY >= board.length ||
          newX < 0 ||
          newX >= board[0].length ||
          board[newY][newX]
        ) {
          return true;
        }
      }
    }
  }
  return false;
}

export function mergeTetromino(board, tetromino, pos, preview = false) {
  const newBoard = board.map(row => [...row]);
  for (let y = 0; y < tetromino.length; y++) {
    for (let x = 0; x < tetromino[0].length; x++) {
      if (tetromino[y][x]) {
        const newY = pos.y + y;
        const newX = pos.x + x;
        if (newY >= 0 && newY < board.length && newX >= 0 && newX < board[0].length) {
          newBoard[newY][newX] = preview ? -tetromino[y][x] : tetromino[y][x];
        }
      }
    }
  }
  return newBoard;
}

export function clearLines(board) {
  let cleared = 0;
  const newBoard = board.filter(row => {
    if (row.every(cell => cell > 0)) {
      cleared++;
      return false;
    }
    return true;
  });
  while (newBoard.length < board.length) {
    newBoard.unshift(Array(board[0].length).fill(0));
  }
  return { newBoard, cleared };
}

export function nextPosition(pos, dir) {
  if (dir === "left") return { ...pos, x: pos.x - 1 };
  if (dir === "right") return { ...pos, x: pos.x + 1 };
  if (dir === "down") return { ...pos, y: pos.y + 1 };
  return pos;
}