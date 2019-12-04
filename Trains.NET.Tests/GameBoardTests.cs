﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using Trains.NET.Engine;
using Xunit;

#nullable disable

namespace Trains.NET.Tests
{
    public class GameBoardTests
    {
        [Fact]
        public void Horizontal()
        {
            var board = new GameBoard();
            board.AddTrack(1, 1);
            board.AddTrack(2, 1);

            Assert.Equal(TrackDirection.Horizontal, board.GetTrackAt(1, 1).Direction);
            Assert.Equal(TrackDirection.Horizontal, board.GetTrackAt(2, 1).Direction);
        }

        [Fact]
        public void Vertical()
        {
            var board = new GameBoard();
            board.AddTrack(1, 1);
            board.AddTrack(1, 2);

            Assert.Equal(TrackDirection.Vertical, board.GetTrackAt(1, 1).Direction);
            Assert.Equal(TrackDirection.Vertical, board.GetTrackAt(1, 2).Direction);
        }

        [Fact]
        public void Two_Verticals()
        {
            var board = new GameBoard();
            board.AddTrack(1, 1);
            board.AddTrack(1, 2);
            board.AddTrack(1, 3);
            board.AddTrack(1, 4);

            board.AddTrack(2, 2);
            board.AddTrack(2, 3);


            Assert.Equal(TrackDirection.Vertical, board.GetTrackAt(1, 1).Direction);
            Assert.Equal(TrackDirection.Vertical, board.GetTrackAt(1, 2).Direction);
            Assert.Equal(TrackDirection.Vertical, board.GetTrackAt(1, 3).Direction);
            Assert.Equal(TrackDirection.Vertical, board.GetTrackAt(1, 4).Direction);

            Assert.Equal(TrackDirection.Vertical, board.GetTrackAt(2, 2).Direction);
            Assert.Equal(TrackDirection.Vertical, board.GetTrackAt(2, 3).Direction);
        }

        [Fact]
        public void LeftUpCorner()
        {
            var board = new GameBoard();
            board.AddTrack(1, 2);
            board.AddTrack(2, 1);
            board.AddTrack(2, 2);

            Assert.Equal(TrackDirection.Horizontal, board.GetTrackAt(1, 2).Direction);
            Assert.Equal(TrackDirection.Vertical, board.GetTrackAt(2, 1).Direction);
            Assert.Equal(TrackDirection.LeftUp, board.GetTrackAt(2, 2).Direction);
        }

        [Fact]
        public void Happiness()
        {
            var board = new GameBoard();
            board.AddTrack(1, 1);

            Assert.False(board.GetTrackAt(1, 1).Happy);

            board.AddTrack(1, 2);

            Assert.False(board.GetTrackAt(1, 1).Happy);
            Assert.False(board.GetTrackAt(1, 2).Happy);

            board.AddTrack(1, 3);

            Assert.False(board.GetTrackAt(1, 1).Happy);
            Assert.True(board.GetTrackAt(1, 2).Happy);
            Assert.False(board.GetTrackAt(1, 3).Happy);
        }
    }
}