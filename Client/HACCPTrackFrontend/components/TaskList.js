import React from "react";
import { View, Text, StyleSheet } from "react-native";
import CategoryCard from "./CategoryCard";

const TaskList = () => {
  return (
    <View style={styles.container}>
      <Text style={styles.heading}>Today's task</Text>
      <View style={styles.taskContainer}>
        <CategoryCard
          title="Restaurant design"
          progress={40}
          color="#00A1F1"
          targetScreen={"RestaurantScreen"}
        />
        <CategoryCard title="Naplók" progress={60} color="#7B2CBF" />
      </View>
      <Text style={styles.heading}>Upcoming task</Text>
      <View style={styles.upcomingTask}>
        <Text>Website design</Text>
        <Text>01 Jan 2024</Text>
      </View>
      <View style={styles.upcomingTask}>
        <Text>Mobile app design</Text>
        <Text>01 Jan 2024</Text>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: 16,
  },
  heading: {
    fontSize: 18,
    fontWeight: "bold",
    marginVertical: 8,
  },
  taskContainer: {
    flexDirection: "row",
    justifyContent: "space-between",
  },
  upcomingTask: {
    backgroundColor: "#F5F5F5",
    padding: 16,
    borderRadius: 10,
    marginVertical: 8,
  },
});

export default TaskList;
