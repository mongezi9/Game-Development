/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tictactoe;

/*
445ddd2ds
Full Name:Emmanuel Mongezi
Surname: Mthimunye
Topic: Assignment 3, Game design
Date: 06 Nov 2015
*/

import java.util.Scanner;

public class TicTacToe
{
	private static final int matrix= 10; // matrix (row and column same value)
	private static char[][] board = new char[matrix][matrix];
    private static boolean winner=false; //flag which will be updated through reference
	
	public static void main( String[] args )
	{
			Scanner keyboard = new Scanner(System.in);
			initBoard(); //call initialization board
			displayBoard(); // display format of empty board
			int elements = board.length * board.length;
			int cntElements=0;
			int position[] = new int[2]; //stores the position 
			char player[] = {'X','O'}; //store player
	  
			while(cntElements<elements && !winner)
			{
					for(int i=0;i<2;i++) //loop for player's index 
					{
							System.out.print("\'"+player[i]+"\', choose your location (row, column):");
							for(int j=0;j<2;j++)//for loop insterting row and column
							{
									position[j]=keyboard.nextInt(); //index zero is always a row and index 1  is always a column		
							}
							//exceptions 
							if(position[0]<matrix && position[1]<matrix)
							{
									//put new values on a board
									if(noCharExisting(position[0],position[1],player[i]))
									{
											//if there is empty space then put players marks on board
											for ( int r=0; r<matrix; r++ )
											{
													System.out.print("\t" + r);//for writing index numbers on the y-axis
													for ( int c=0; c<matrix; c++ )
													{
															board[position[0]][position[1]] = player[i];
															System.out.print("|"+"_" + board[r][c] );//placing mark's player in specified position	
															System.out.print('_');
													}
													System.out.println("|");
											}
											System.out.print("\t");
											for(int k=0;k<matrix;k++)// for writing index number on the x-axis
											{
													System.out.printf("%4d",k);
											}
											System.out.println();
											winner(position[0],position[1],player[i]);//update winner boolean variable
											if(winner)//if there is winner
											{
													break;
											}
									}
									else
									{
											//if there is char existing error, re-enter new position for prevois player
											System.out.println("There is a mark already!, try different position");
											i--; //decrement index of player to get the previous one
											cntElements--; //and also decrement the played elements 
									}
									cntElements++;
									if(cntElements==elements) //if all element are filled and no winner it means zidlana uboya! LOL
									{
											System.out.println(" ");
											System.out.println("The game is a tie");
											break;	
									}
							}
							else//error index was outside of bound
							{
									System.out.println("Error!! the index was out of bound row and column must be between (0 to "+ (matrix-1)+") re-enter mchana ");
									i--;
							}
					}
			}
	}
	public static void initBoard()
	{
			// fills up the board with blanks
			for ( int r=0; r<matrix; r++ )
					for ( int c=0; c<matrix; c++ )
							board[r][c] = ' ';
	}
	public static void displayBoard()
	{
			for ( int r=0; r<matrix; r++ )
			{
					System.out.print("\t" + r);//for writing index numbers on the y-axis
					for ( int c=0; c<matrix; c++ )
					{			
							System.out.print("|"+"_" + board[r][c] );//placing mark's player in specified position	
							System.out.print('_');
					}
					System.out.println("|");
			}
			System.out.print("\t");
			for(int k=0;k<matrix;k++)// for writing index number on the x-axis
			{
					System.out.printf("%4d",k);
			}
			System.out.println();
	}
	public static boolean noCharExisting(int row, int col, char player)//function to determine whether there is no mark in desired position
	{
			//update and check if there is no element that exist
			if(board[row][col]!='X' && board[row][col]!='O')
			{
					return true; //there is no character
			}
			else
			{
					return false; // there is character
			}		
	}
	public static void winner(int row, int col, char playerName)//the function determine winner and displays the winner eiher horizontaly, vert, or diagon
	{
			int[][] collectScore={{0,0,0,0},{0,0,0,0}};//1 column:stores horizontal points.2 column:stores vertical points.3 & 4 columns: Diagonal points left and right
			char[] player = {'X','O'};//store the players name
			String[] typeWin = {"Horizonal","Vertical","Diagonal back","Diagonal foward"}; //stores the type of axis
			int m=0;
			for(int k=0;k<matrix;k++)
			{
					if(board[row][k] == board[row][col])//horizontal
					{
							if(playerName == 'X')
							{
									collectScore[0][0]++; //horizontal element for X
							}
							else if(playerName == 'O')
							{
									collectScore[1][0]++;//horizontal element for O
							}						
					}
					if(board[k][col]==board[row][col])//vertical
					{
							if(playerName == 'X')
							{
									collectScore[0][1]++; //vertical element for X
							}
							else if(playerName == 'O')
							{
									collectScore[1][1]++; //vertical element for O
							}	
					}
					if(board[k][m]==board[row][col] && m==k)//diagonal
					{
							if(playerName == 'X')
							{
									collectScore[0][2]++; //diagonal back element for X
							}
							else if(playerName == 'O')
							{
									collectScore[1][2]++; //diagonal back element for O
							}	
					}
					if(board[(matrix-1)-k][m]==board[row][col] && m==k)//diagonal Up and Down couter
					{
							if(playerName == 'X')
							{
									collectScore[0][3]++;// diagonal foward element for X
							}
							else if(playerName == 'O')
							{
									collectScore[1][3]++;// diagonal foward element for O
							}	
					}
				m++;
			}
			//switching 
			for(int i=0;i<2;i++) 
			{
				for(int j=0;j<4;j++)
				{
					switch(collectScore[i][j])//switch to element that has the higher score which matches the matrix value
					{
							case matrix:
									winner= true; //update the value of a winner
									System.out.println("The winner is \'"+player[i]+"\' "+typeWin[j]+" match! ");
									break;
							default:
									break;
					}
				}
			}
	}
}

	
