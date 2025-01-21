package javaapplication2;

public class UnOrderedArray {
    private int[] m_array;
    private int maxSize;
    private int numElements;
    
    public UnOrderedArray( int size){
        numElements=0;
        maxSize=size;
        m_array = new int[maxSize];
    }
    
    public boolean addLast(int item){
        if (numElements<maxSize){
            m_array[numElements]=item;
            numElements++;
            return true;
        }
        return false;
    }
    
    public void listItems(){
        for (int x=0;x<numElements;x++){
            System.out.print(m_array[x]+" ");
        }
        System.out.println("");       
    }
    
    public int linearSearch(int key){
        for (int x=0;x<numElements;x++){
            if(m_array[x]==key){
                return x;
            }
        }
         return -1;
    }
    
    public boolean efficientRemoveItem(int index){
        if (index>=0 && index<numElements){
            m_array[index] =m_array[numElements-1];
            numElements--;
            return true;
        }
        return false;
    }
    
    public boolean removeItem(int key){
        int loc = linearSearch(key);
        if (loc!=-1){
            return efficientRemoveItem(loc);
        }
        return false;
    }
    
    public void selectionSort(){// ascending
        for (int start=0;start<numElements-1;start++){
            int smallestLoc=start;
            for (int pos=start+1;pos<numElements;pos++){
                if (m_array[pos]<m_array[smallestLoc]){
                    smallestLoc=pos;
                }
            }
            int temp = m_array[start];
            m_array[start]=m_array[smallestLoc];
            m_array[smallestLoc]=temp;
        }
    }
    
    public void insertionSort() {
        for (int start=1; start<numElements;start++){
            int temp = m_array[start];
            int prev =start-1;
            while (prev>=0 && m_array[prev]>temp){
                m_array[prev+1]=m_array[prev];
                prev--;
            }
            m_array[prev+1]=temp;
        }
    }
    
    public int binarySearch(int key){
        int lo=0,hi=numElements-1,mid;
        while (lo<=hi){
            mid =(lo+hi)/2;
            if (m_array[mid]==key) return mid;
            if (m_array[mid]>key) hi= mid-1;
            if (m_array[mid]<key) lo= mid+1;
        }
        return -1;
    }
    
}


// remember to import java.util.*;
 public static void main(String[] args) {
        Random rand = new Random();
        int size=10;
        UnOrderedArray a1 = new UnOrderedArray(size);
        for (int x=0;x<size;x++){
            a1.addLast(rand.nextInt(20));
        }
        a1.listItems();
       // a1.selectionSort();
        a1.insertionSort();
        a1.listItems();
        System.out.println(a1.binarySearch(10));
    }