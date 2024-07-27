import React from "react";
import { View, Text, StyleSheet, Image } from "react-native";

const ProfileHeader = () => {
  return (
    <View style={styles.container}>
      <Image
        style={styles.profilePic}
        source={{ uri: "https://example.com/profile-pic.png" }}
      />
      <View>
        <Text style={styles.greeting}>Hi, Shahinur</Text>
        <Text style={styles.date}>01 Jan 2024</Text>
      </View>
      <View style={styles.notificationIcon}>{/* Notification Icon */}</View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
    padding: 16,
  },
  profilePic: {
    width: 40,
    height: 40,
    borderRadius: 20,
  },
  greeting: {
    fontSize: 18,
    fontWeight: "bold",
  },
  date: {
    fontSize: 14,
    color: "gray",
  },
  notificationIcon: {
    // styles for notification icon
  },
});

export default ProfileHeader;
